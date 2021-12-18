using System;
using System.Runtime.InteropServices;

namespace Tasler.SQLite.Interop
{
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

	internal static partial class SQLiteApi
	{
		private const string ApiLib = "sqlite3";

		internal static readonly IntPtr SQLITE_STATIC    = IntPtr.Zero;
		internal static readonly IntPtr SQLITE_TRANSIENT = new(-1);

		#region Connection Imports

		#region Constructor and Destructor

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_open_v2(
			[MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
			out SQLiteConnection connection,
			SQLiteOpenFlags flags,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string vfsModuleName);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_close_v2(IntPtr connectionHandle);

		#endregion Constructor and Destructor

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_errcode(SQLiteConnection connection);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_errmsg16(SQLiteConnection connection);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_extended_errcode(SQLiteConnection connection);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern void sqlite3_interrupt(SQLiteConnection connection);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_table_column_metadata(
			SQLiteConnection connection,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string dbName,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string tableName,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string columnName,
			out IntPtr dataTypeNamePtr,
			out IntPtr collationSequenceNamePtr,
			[MarshalAs(UnmanagedType.Bool)] out bool isNotNullable,
			[MarshalAs(UnmanagedType.Bool)] out bool isPrimaryKey,
			[MarshalAs(UnmanagedType.Bool)] out bool isAutoIncrement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_db_cacheflush(SQLiteConnection connection);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_db_filename(
			SQLiteConnection connection,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string dbName);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int sqlite3_db_readonly(
			SQLiteConnection connection,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string dbName);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_db_status(
			SQLiteConnection connection,
			SQLiteDatabaseStatus operation,
			out int current,
			out int highWater,
			[MarshalAs(UnmanagedType.Bool)] bool resetHighWater);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool sqlite3_get_autocommit(SQLiteConnection connection);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern long sqlite3_last_insert_rowid(SQLiteConnection connection);

		#endregion Connection Imports

		#region Statement Imports

		#region Constructor and Destructor

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_prepare16_v2(
			SQLiteConnection connection,
			string sqlQuery,
			int sqlQueryByteLength,
			out SQLiteStatement statement,
			IntPtr reservedMustBeZero);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_finalize(IntPtr statementHandle);

		#endregion Constructor and Destructor

		#region Methods

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_reset(SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_step(SQLiteStatement statement);

		#endregion Methods

		#region Properties

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteStatementIsExplain sqlite3_stmt_isexplain(SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool sqlite3_stmt_readonly(SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int sqlite3_stmt_status(
			SQLiteStatement statement,
			SQLiteStatementStatus counter,
			[MarshalAs(UnmanagedType.Bool)] bool resetFlag);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_sql(SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_expanded_sql(SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_normalized_sql(SQLiteStatement statement);

		#endregion Properties

		#region Column Binding

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static unsafe extern SQLiteExtendedResultCode sqlite3_bind_blob(
			SQLiteStatement statement,
			int parameterIndex,
			IntPtr value,
			int byteCount,
			delegate* unmanaged<void*, void> releaseCallback);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_bind_double(
			SQLiteStatement statement,
			int parameterIndex,
			double value);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_bind_int(
			SQLiteStatement statement,
			int parameterIndex,
			int value);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_bind_int64(
			SQLiteStatement statement,
			int parameterIndex,
			long value);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_bind_null(
			SQLiteStatement statement,
			int parameterIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static unsafe extern SQLiteExtendedResultCode sqlite3_bind_text16(
			SQLiteStatement statement,
			int parameterIndex,
			char* value,
			int byteCount,
			IntPtr releaseCallback);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_bind_zeroblob(
			SQLiteStatement statement,
			int parameterIndex,
			int byteCount);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int sqlite3_bind_parameter_count(
			SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_bind_parameter_name(
			SQLiteStatement statement,
			int parameterIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int sqlite3_bind_parameter_index(
			SQLiteStatement statement,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string parameterName);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_clear_bindings(
			SQLiteStatement statement);

		#endregion Column Binding

		#region Result Column Values

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static unsafe extern void* sqlite3_column_blob(
			SQLiteStatement statement,
			int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int sqlite3_column_bytes(
			SQLiteStatement statement,
			int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int sqlite3_column_count(
			SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_column_database_name16(SQLiteStatement statement, int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_column_decltype16(SQLiteStatement statement, int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern double sqlite3_column_double(
			SQLiteStatement statement,
			int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int sqlite3_column_int(
			SQLiteStatement statement,
			int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern long sqlite3_column_int64(
			SQLiteStatement statement,
			int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_column_name16(SQLiteStatement statement, int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_column_origin_name16(SQLiteStatement statement, int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_column_table_name16(SQLiteStatement statement, int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_column_text16(SQLiteStatement statement, int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteDataType sqlite3_column_type(SQLiteStatement statement, int columnIndex);

		#endregion Result Column Values

		#endregion Statement Imports

		#region Blob Imports

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_blob_open(
			SQLiteConnection connection,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string dbName,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string tableName,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string columnName,
			long rowIndex,
			[MarshalAs(UnmanagedType.Bool)] bool openWritable,
			out SQLiteBlob blob);

		#endregion Blob Imports

		#region Error Code Imports

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_errstr(SQLiteResultCode resultCode);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_errstr(SQLiteExtendedResultCode resultCode);

		internal static SQLiteResultCode GetPrimaryResult(SQLiteExtendedResultCode resultCode)
		{
			return (SQLiteResultCode)((uint)resultCode & 0xFF);
		}

		#endregion Error Code Imports

		#region Memory Management Imports

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_malloc(int size);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_malloc64(ulong size);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_realloc(IntPtr pointer, int size);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_realloc64(IntPtr pointer, ulong size);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern void sqlite3_free(IntPtr pointer);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern ulong sqlite3_msize(IntPtr pointer);

		#endregion Memory Management Imports
	}

#pragma warning restore CA2101
}
