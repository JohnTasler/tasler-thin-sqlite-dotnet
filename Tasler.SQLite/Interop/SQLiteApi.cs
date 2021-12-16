using System;
using System.Runtime.InteropServices;

namespace Tasler.SQLite.Interop
{
	internal static class SQLiteApi
	{
		private const string ApiLib = "sqlite3";

		internal static readonly IntPtr SQLITE_STATIC    = IntPtr.Zero;
		internal static readonly IntPtr SQLITE_TRANSIENT = new(-1);

		#region Methods

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static unsafe extern SQLiteResultCode sqlite3_bind_blob(
			SQLiteStatement statement,
			int parameterIndex,
			IntPtr value,
			int byteCount,
			delegate* unmanaged<void*, void> releaseCallback);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_bind_double(
			SQLiteStatement statement,
			int parameterIndex,
			double value);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_bind_int(
			SQLiteStatement statement,
			int parameterIndex,
			int value);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_bind_int64(
			SQLiteStatement statement,
			int parameterIndex,
			long value);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_bind_null(
			SQLiteStatement statement,
			int parameterIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static unsafe extern SQLiteResultCode sqlite3_bind_text16(
			SQLiteStatement statement,
			int parameterIndex,
			char* value,
			int byteCount,
			IntPtr releaseCallback);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_bind_zeroblob(
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
		internal static extern SQLiteResultCode sqlite3_clear_bindings(
			SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_close_v2(IntPtr connectionHandle);

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
		internal static extern SQLiteDataType sqlite3_column_type(
			SQLiteStatement statement,
			int columnIndex);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_errcode(SQLiteConnection connection);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_errmsg16(SQLiteConnection connection);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_errstr(SQLiteResultCode resultCode);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern IntPtr sqlite3_errstr(SQLiteExtendedResultCode resultCode);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteExtendedResultCode sqlite3_extended_errcode(SQLiteConnection connection);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int sqlite3_extended_result_codes(
			SQLiteConnection connection,
			[MarshalAs(UnmanagedType.Bool)] bool enableExtendedResultCodes);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_finalize(IntPtr statementHandle);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_open_v2(
			[MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
			out SQLiteConnection connection,
			SQLiteOpenFlags flags,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string vfsModuleName);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_prepare16_v2(
			SQLiteConnection connection,
			string sqlQuery,
			int sqlQueryByteLength,
			out SQLiteStatement statement,
			IntPtr reservedMustBeZero);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_reset(SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_step(SQLiteStatement statement);

		[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern SQLiteResultCode sqlite3_table_column_metadata(SQLiteConnection connection,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string dbName,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string tableName,
			[MarshalAs(UnmanagedType.LPUTF8Str)] string columnName,
			out IntPtr dataTypeNamePtr,
			out IntPtr collationSequenceNamePtr,
			[MarshalAs(UnmanagedType.Bool)] out bool isNotNullable,
			[MarshalAs(UnmanagedType.Bool)] out bool isPrimaryKey,
			[MarshalAs(UnmanagedType.Bool)] out bool isAutoIncrement);

		#endregion Methods
	}
}
