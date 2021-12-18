using System;
using System.Runtime.InteropServices;
using Tasler.SQLite.Interop;

namespace Tasler.SQLite
{
	public sealed class SQLiteConnection : SQLiteSafeHandle
	{
		public static SQLiteConnection Open(
			string filename,
			SQLiteOpenFlags flags = SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite)
		{
			SQLiteConnection connection;
			ThrowOnError(SQLiteApi.sqlite3_open_v2(filename, out connection, flags | SQLiteOpenFlags.ExtendedResults, null));
			return connection;
		}

		public SQLiteStatement PrepareStatement(string sqlQuery)
		{
			SQLiteStatement statement;
			ThrowOnError(SQLiteApi.sqlite3_prepare16_v2(
				this, sqlQuery, (sqlQuery.Length + 1) * sizeof(char), out statement, IntPtr.Zero));
			statement.Connection = this;
			return statement;
		}

		public SQLiteColumnDefinition GetTableColumnMetadata(
			string dbName,
			string tableName,
			string columnName)
		{
			ThrowOnError(
				SQLiteApi.sqlite3_table_column_metadata(
					this, dbName, tableName, columnName,
					out var dataTypeName, out var collationSequenceName,
					out var isNotNullable, out var isPrimaryKey, out var isAutoIncrement)
				);

			return new SQLiteColumnDefinition
			{
				Name = columnName,
				TableName = tableName,
				DatabaseName = dbName,
				DataTypeName = Marshal.PtrToStringAnsi(dataTypeName),
				CollationSequenceName = Marshal.PtrToStringAnsi(collationSequenceName),
				IsNotNullable = isNotNullable,
				IsPrimaryKey = isPrimaryKey,
				IsAutoIncrement = isAutoIncrement
			};
		}

		public string GetDatabaseFileName(string dbName) => Marshal.PtrToStringUTF8(SQLiteApi.sqlite3_db_filename(this, dbName));

		public void FlushCache()
		{
			ThrowOnError(SQLiteApi.sqlite3_db_cacheflush(this));
		}

		public bool? GetIsDatabaseReadOnly(string dbName)
		{
			var result = SQLiteApi.sqlite3_db_readonly(this, dbName);
			return result >= 0 ? result != 0 : null;
		}

		public int GetDatabaseStatus(SQLiteDatabaseStatus operation, out int highWater, bool resetHighWater)
		{
			ThrowOnError(SQLiteApi.sqlite3_db_status(this, operation, out var current, out highWater, resetHighWater));
			return current;
		}

		public bool IsAutoCommit => SQLiteApi.sqlite3_get_autocommit(this);

		public void Interrupt() => SQLiteApi.sqlite3_interrupt(this);

		public long LastInsertRowId => SQLiteApi.sqlite3_last_insert_rowid(this);

		public static string GetErrorMessage(SQLiteResultCode resultCode) => Marshal.PtrToStringUTF8(SQLiteApi.sqlite3_errstr(resultCode));

		public static string GetErrorMessage(SQLiteExtendedResultCode resultCode) => Marshal.PtrToStringUTF8(SQLiteApi.sqlite3_errstr(resultCode));

		public SQLiteResultCode LastErrorCode => SQLiteApi.sqlite3_errcode(this);

		public SQLiteExtendedResultCode LastExtendedErrorCode => SQLiteApi.sqlite3_extended_errcode(this);

		public string LastErrorMessage => Marshal.PtrToStringUni(SQLiteApi.sqlite3_errmsg16(this));

		public string LastExtendedErrorMessage => Marshal.PtrToStringUTF8(SQLiteApi.sqlite3_errstr(this.LastExtendedErrorCode));

		protected override bool ReleaseHandle()
		{
			var errorCode = SQLiteApi.sqlite3_close_v2(this.handle);
			this.handle = IntPtr.Zero;
			return errorCode == SQLiteExtendedResultCode.Ok;
		}

		private static void ThrowOnError(SQLiteExtendedResultCode extendedErrorCode)
		{
			if (extendedErrorCode != SQLiteExtendedResultCode.Ok)
			{
				throw new SQLiteConnectionException(extendedErrorCode);
			}
		}
	}
}
