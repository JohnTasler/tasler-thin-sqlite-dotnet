using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Tasler.SQLite.Interop;

namespace Tasler.SQLite
{
	public sealed class SQLiteStatement : SQLiteSafeHandle
	{
		public SQLiteConnection Connection { get; internal set; }

		public IList<SQLiteColumnDefinition> ColumnDefinitions
		{
			get
			{
				var columnCount = SQLiteApi.sqlite3_column_count(this);
				var columnDefinitions = new SQLiteColumnDefinition[columnCount];
				for (var columnIndex = 0; columnIndex < columnCount; ++columnIndex)
				{
					var databaseName = Marshal.PtrToStringUni(SQLiteApi.sqlite3_column_database_name16(this, columnIndex));
					var tableName = Marshal.PtrToStringUni(SQLiteApi.sqlite3_column_table_name16(this, columnIndex));
					var originName = Marshal.PtrToStringUni(SQLiteApi.sqlite3_column_origin_name16(this, columnIndex));

					columnDefinitions[columnIndex] = this.Connection.GetTableColumnMetadata(
						databaseName, tableName, originName);
				}

				return columnDefinitions;
			}
		}

		public int GetParameterNameIndex(string parameterName)
		{
			if (parameterName == null)
				throw new ArgumentNullException(nameof(parameterName));

			var parameterIndex = SQLiteApi.sqlite3_bind_parameter_index(this, parameterName);
			if (parameterIndex == 0)
				throw new ArgumentException($"The SQLiteStatement has no matching parameter name: {parameterName}", nameof(parameterName));

			return parameterIndex;
		}

		public void BindTextParameter(string parameterName, string value)
		{
			this.BindTextParameter(GetParameterNameIndex(parameterName), value);
		}

		public void BindTextParameter(int parameterIndex, string value)
		{
			value ??= string.Empty;
			var byteCount = value.Length * sizeof(char);

			var result = default(SQLiteExtendedResultCode);
			unsafe
			{
				fixed (char* pointer = value)
				{
					result = SQLiteApi.sqlite3_bind_text16(this, parameterIndex, pointer, byteCount, Interop.SQLiteApi.SQLITE_TRANSIENT);
				}
			}

			ThrowIfError(result);
		}

		public SQLiteStatementIsExplain IsExplain
		{
			get
			{
				try
				{
					return SQLiteApi.sqlite3_stmt_isexplain(this);
				}
				catch
				{
					return SQLiteStatementIsExplain.False;
				}
			}
		}

		/// <summary>
		/// Determines if the prepared statement makes no direct changes to the content of the database file.
		/// </summary>
		/// <remarks>
		/// Note that application-defined SQL functions or virtual tables might change the database indirectly as a
		/// side effect. For example, if an application defines a function "eval()" that calls sqlite3_exec(), then
		/// the following SQL statement would change the database file through side-effects:
		/// <code>
		/// SELECT eval('DELETE FROM t1') FROM t2;
		/// </code>
		/// <para>But because the SELECT statement does not change the database file directly, <see cref="IsReadOnly"/>
		/// would still return <c>true</c>.</para>
		/// <para> Transaction control statements such as BEGIN, COMMIT, ROLLBACK, SAVEPOINT, and RELEASE cause
		/// <see cref="IsReadOnly"/> to return <c>true</c>, since the statements themselves do not actually modify
		/// the database but rather they control the timing of when other statements modify the database. The ATTACH
		/// and DETACH statements also cause <see cref="IsReadOnly"/> to return <c>true</c> since, while those
		/// statements change the configuration of a database connection, they do not make changes to the content
		/// of the database files on disk. The <see cref="IsReadOnly"/> interface returns <c>true</c> for BEGIN
		/// since BEGIN merely sets internal flags, but the BEGIN IMMEDIATE and BEGIN&nbsp;EXCLUSIVE commands do touch the
		/// database and so <see cref="IsReadOnly"/> returns <c>false</c> for those commands.</para>
		/// <para>This routine returns <c>false</c> if there is any possibility that the statement might change the
		/// database file. A <c>false</c> return does not guarantee that the statement will change the database file.
		/// For example, an UPDATE statement might have a WHERE clause that makes it a no-op, but the
		/// <see cref="IsReadOnly"/> result would still be <c>false</c>. Similarly, a
		/// CREATE&nbsp;TABLE&nbsp;IF&nbsp;NOT&nbsp;EXISTS statement is a read-only no-op if the table already exists,
		/// but <see cref="IsReadOnly"/> still returns <c>false</c> for such a statement.</para>
		/// </remarks>
		public bool IsReadOnly => SQLiteApi.sqlite3_stmt_readonly(this);

		/// <summary>
		/// Gets and, optionally, resets the specified prepared statement counter value.
		/// </summary>
		/// <param name="counter">The counter to be interrogated</param>
		/// <param name="resetCounter">When <c>true</c>, the requested <paramref name="counter"/> is reset to zero.</param>
		/// <returns>The current value of the requested <paramref name="counter"/>.</returns>
		/// <remarks>
		/// Each prepared statement maintains various <see cref="SQLiteStatementStatus"/> counters that measure the
		/// number of times it has performed specific operations. These counters can be used to monitor the
		/// performance characteristics of the prepared statements. For example, if the number of table steps
		/// greatly exceeds the number of table searches or result rows, that would tend to indicate that the
		/// prepared statement is using a full table scan rather than an index.
		/// </remarks>
		public int GetStatus(SQLiteStatementStatus counter, bool resetCounter) =>
			SQLiteApi.sqlite3_stmt_status(this, counter, resetCounter);

		public string Sql => Marshal.PtrToStringUTF8(SQLiteApi.sqlite3_sql(this));

		public string ExpandedSql
		{
			get
			{
				try
				{
					var pointer = SQLiteApi.sqlite3_expanded_sql(this);
					var result = Marshal.PtrToStringUTF8(pointer);
					SQLiteApi.sqlite3_free(pointer);
					return result;
				}
				catch
				{
					return null;
				}
			}
		}

		public string NormalizedSql
		{
			get
			{
				try
				{
					return Marshal.PtrToStringUTF8(SQLiteApi.sqlite3_normalized_sql(this));
				}
				catch
				{
					return null;
				}
			}
		}

		public void Execute() => _ = GetRows().FirstOrDefault();

		public IEnumerable<SQLiteRow> GetRows()
		{
			this.Reset();

			for (var result = SQLiteApi.sqlite3_step(this); result != SQLiteExtendedResultCode.Done; result = SQLiteApi.sqlite3_step(this))
			{
				switch (result)
				{
					case SQLiteExtendedResultCode.Row:
						yield return new SQLiteRow(this);
						break;

					case SQLiteExtendedResultCode.Busy:
						Thread.Sleep(0);
						break;

					case SQLiteExtendedResultCode.Done:
						break;

					default:
						ThrowIfError(result);
						break;
				}
			}
		}

		/// <summary>
		/// Reset the statement object back to its initial state, ready to be re-executed. Any SQL statement
		/// variables that had values bound to them using the sqlite3_bind_*() API retain their values.
		/// Use <see cref="ClearBindings"/> to reset the bindings.
		/// </summary>
		public void Reset() => ThrowIfError(SQLiteApi.sqlite3_reset(this));

		/// <summary>
		/// Resets all host parameters to <c>null</c>.
		/// </summary>
		public void ClearBindings() => ThrowIfError(SQLiteApi.sqlite3_clear_bindings(this));

		protected override bool ReleaseHandle()
		{
			var errorCode = SQLiteApi.sqlite3_finalize(this.handle);
			this.handle = IntPtr.Zero;
			return errorCode == SQLiteExtendedResultCode.Ok;
		}

		private static void ThrowIfError(SQLiteExtendedResultCode errorCode)
		{
			if (errorCode != SQLiteExtendedResultCode.Ok)
				throw new SQLiteStatementException(errorCode);
		}
	}
}
