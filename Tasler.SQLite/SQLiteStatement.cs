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
		internal readonly object _lockObject = new object();

		private SQLiteColumnDefinition[] _columnDefinitions;
		public IList<SQLiteColumnDefinition> ColumnDefinitions
		{
			get
			{
				lock (_lockObject)
				{
					if (_columnDefinitions == null)
					{
						var columnCount = SQLiteApi.sqlite3_column_count(this);
						var columnDefinitions = new SQLiteColumnDefinition[columnCount];
						for (var columnIndex = 0; columnIndex < columnCount; ++columnIndex)
						{
							var databaseName = Marshal.PtrToStringUni(SQLiteApi.sqlite3_column_database_name16(this, columnIndex));
							var tableName = Marshal.PtrToStringUni(SQLiteApi.sqlite3_column_table_name16(this, columnIndex));
							var originName = Marshal.PtrToStringUni(SQLiteApi.sqlite3_column_origin_name16(this, columnIndex));

							if (databaseName != null && tableName != null && originName != null)
								columnDefinitions[columnIndex] =
									this.Connection.GetTableColumnMetadata(databaseName, tableName, originName);
						}

						_columnDefinitions = columnDefinitions;
					}

					return _columnDefinitions;
				}
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
			value = value ?? string.Empty;
			var byteCount = value.Length * sizeof(char);

			var result = default(SQLiteResultCode);
			unsafe
			{
				fixed (char* pointer = value)
				{
					result = SQLiteApi.sqlite3_bind_text16(this, parameterIndex, pointer, byteCount, Interop.SQLiteApi.SQLITE_TRANSIENT);
				}
			}

			ThrowOnError(result);
		}

		public SQLiteConnection Connection { get; internal set; }

		public void Execute()
		{
			GetRows().FirstOrDefault();
		}

		public IEnumerable<SQLiteRow> GetRows()
		{
			lock (_lockObject)
				_columnDefinitions = null;

			this.Reset();

			var result = default(SQLiteResultCode);
			while (result != SQLiteResultCode.Done)
			{
				lock (_lockObject)
					result = SQLiteApi.sqlite3_step(this);

				if (result == SQLiteResultCode.Row)
				{
					var row = new SQLiteRow(this);
					yield return row;
				}
				else if (result == SQLiteResultCode.Busy)
				{
					Thread.Sleep(0);
				}
				else if (result != SQLiteResultCode.Done)
				{
					ThrowOnError(result);
				}
			}
		}

		public void Reset()
		{
			var result = SQLiteApi.sqlite3_reset(this);
			ThrowOnError(result);
		}

		protected override bool ReleaseHandle()
		{
			var errorCode = SQLiteApi.sqlite3_finalize(this.handle);
			this.handle = IntPtr.Zero;
			return errorCode == SQLiteResultCode.Ok;
		}

		private void ThrowOnError(SQLiteResultCode errorCode)
		{
			if (errorCode != SQLiteResultCode.Ok)
				throw new SQLiteStatementException(this);
		}
	}
}
