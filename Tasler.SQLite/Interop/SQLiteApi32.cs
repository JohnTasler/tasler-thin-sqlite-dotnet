using System;
using System.Runtime.InteropServices;

namespace Tasler.SQLite.Interop
{
	internal class SQLiteApi32 : ISQLiteApi
	{
		internal static class NativeMethods
		{
			private const string ApiLib = "Tasler.SQLite\\Library\\sqlite3-x86.dll";

			#region Methods

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_bind_blob(
					SQLiteStatement statement,
					int parameterIndex,
					IntPtr value,
					int byteCount,
					[MarshalAs(UnmanagedType.FunctionPtr)] SQLiteApi.MemoryReleaseCallback releaseCallback);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_bind_double(
					SQLiteStatement statement,
					int parameterIndex,
					double value);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_bind_int(
					SQLiteStatement statement,
					int parameterIndex,
					int value);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_bind_int64(
					SQLiteStatement statement,
					int parameterIndex,
					long value);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_bind_null(
					SQLiteStatement statement,
					int parameterIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_bind_text16(
					SQLiteStatement statement,
					int parameterIndex,
					IntPtr value,
					int byteCount,
					[MarshalAs(UnmanagedType.FunctionPtr)] SQLiteApi.MemoryReleaseCallback releaseCallback);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_bind_zeroblob(
					SQLiteStatement statement,
					int parameterIndex,
					int byteCount);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			int sqlite3_bind_parameter_count(
					SQLiteStatement statement);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			IntPtr sqlite3_bind_parameter_name(
					SQLiteStatement statement,
					int parameterIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			int sqlite3_bind_parameter_index(
					SQLiteStatement statement,
					[MarshalAs(UnmanagedType.LPStr)] string parameterName);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_clear_bindings(
					SQLiteStatement statement);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_close_v2(IntPtr connectionHandle);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			IntPtr sqlite3_column_blob(
					SQLiteStatement statement,
					int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			int sqlite3_column_bytes(
					SQLiteStatement statement,
					int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			int sqlite3_column_count(
					SQLiteStatement statement);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
//			[return: MarshalAs(UnmanagedType.LPWStr)]
			internal static extern
			IntPtr sqlite3_column_database_name16(SQLiteStatement statement, int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			IntPtr sqlite3_column_decltype16(SQLiteStatement statement, int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			double sqlite3_column_double(
					SQLiteStatement statement,
					int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			int sqlite3_column_int(
					SQLiteStatement statement,
					int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			long sqlite3_column_int64(
					SQLiteStatement statement,
					int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			IntPtr sqlite3_column_name16(SQLiteStatement statement, int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			IntPtr sqlite3_column_origin_name16(SQLiteStatement statement, int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			IntPtr sqlite3_column_table_name16(SQLiteStatement statement, int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			IntPtr sqlite3_column_text16(SQLiteStatement statement, int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteDataType sqlite3_column_type(
					SQLiteStatement statement,
					int columnIndex);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_errcode(
					SQLiteConnection connection);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			IntPtr sqlite3_errmsg16(SQLiteConnection connection);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			IntPtr sqlite3_errstr(SQLiteResultCode resultCode);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "sqlite3_errstr")]
			internal static extern
			IntPtr sqlite3_extended_errstr(SQLiteExtendedResultCode resultCode);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteExtendedResultCode sqlite3_extended_errcode(
					SQLiteConnection connection);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			int sqlite3_extended_result_codes(
					SQLiteConnection connection,
					[MarshalAs(UnmanagedType.Bool)] bool enableExtendedResultCodes);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_finalize(IntPtr statementHandle);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_open_v2(
					[MarshalAs(UnmanagedType.LPStr)] string filename,
					out SQLiteConnection connection,
					SQLiteOpenFlags flags,
					[MarshalAs(UnmanagedType.LPStr)] string vfsModuleName);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_prepare16_v2(
					SQLiteConnection connection,
					[MarshalAs(UnmanagedType.LPWStr)] string sqlQuery,
					int sqlQueryByteLength,
					out SQLiteStatement statement,
					IntPtr reservedMustBeZero);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_reset(SQLiteStatement statement);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_step(
					SQLiteStatement statement);

			[DllImport(ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
			internal static extern
			SQLiteResultCode sqlite3_table_column_metadata(SQLiteConnection connection,
					[MarshalAs(UnmanagedType.LPStr)] string dbName,
					[MarshalAs(UnmanagedType.LPStr)] string tableName,
					[MarshalAs(UnmanagedType.LPStr)] string columnName,
					out IntPtr dataTypeNamePtr,
					out IntPtr collationSequenceNamePtr,
					[MarshalAs(UnmanagedType.Bool)] out bool isNotNullable,
					[MarshalAs(UnmanagedType.Bool)] out bool isPrimaryKey,
					[MarshalAs(UnmanagedType.Bool)] out bool isAutoIncrement);

			#endregion Methods
		}

		#region ISQLiteApi Implementation

		public SQLiteResultCode sqlite3_bind_blob(SQLiteStatement statement, int parameterIndex, IntPtr value, int byteCount, SQLiteApi.MemoryReleaseCallback releaseCallback)
		{
			return NativeMethods.sqlite3_bind_blob(statement, parameterIndex, value, byteCount, releaseCallback);
		}

		public SQLiteResultCode sqlite3_bind_double(SQLiteStatement statement, int parameterIndex, double value)
		{
			return NativeMethods.sqlite3_bind_double(statement, parameterIndex, value);
		}

		public SQLiteResultCode sqlite3_bind_int(SQLiteStatement statement, int parameterIndex, int value)
		{
			return NativeMethods.sqlite3_bind_int(statement, parameterIndex, value);
		}

		public SQLiteResultCode sqlite3_bind_int64(SQLiteStatement statement, int parameterIndex, long value)
		{
			return NativeMethods.sqlite3_bind_int64(statement, parameterIndex, value);
		}

		public SQLiteResultCode sqlite3_bind_null(SQLiteStatement statement, int parameterIndex)
		{
			return NativeMethods.sqlite3_bind_null(statement, parameterIndex);
		}

		public SQLiteResultCode sqlite3_bind_text16(SQLiteStatement statement, int parameterIndex, IntPtr value, int byteCount, SQLiteApi.MemoryReleaseCallback releaseCallback)
		{
			return NativeMethods.sqlite3_bind_text16(statement, parameterIndex, value, byteCount, releaseCallback);
		}

		public SQLiteResultCode sqlite3_bind_zeroblob(SQLiteStatement statement, int parameterIndex, int byteCount)
		{
			return NativeMethods.sqlite3_bind_zeroblob(statement, parameterIndex, byteCount);
		}

		public int sqlite3_bind_parameter_count(SQLiteStatement statement)
		{
			return NativeMethods.sqlite3_bind_parameter_count(statement);
		}

		public IntPtr sqlite3_bind_parameter_name(SQLiteStatement statement, int parameterIndex)
		{
			return NativeMethods.sqlite3_bind_parameter_name(statement, parameterIndex);
		}

		public int sqlite3_bind_parameter_index(SQLiteStatement statement, string parameterName)
		{
			return NativeMethods.sqlite3_bind_parameter_index(statement, parameterName);
		}

		public SQLiteResultCode sqlite3_clear_bindings(SQLiteStatement statement)
		{
			return NativeMethods.sqlite3_clear_bindings(statement);
		}

		public SQLiteResultCode sqlite3_close_v2(IntPtr connectionHandle)
		{
			return NativeMethods.sqlite3_close_v2(connectionHandle);
		}

		public IntPtr sqlite3_column_blob(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_blob(statement, columnIndex);
		}

		public int sqlite3_column_bytes(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_bytes(statement, columnIndex);
		}

		public int sqlite3_column_count(SQLiteStatement statement)
		{
			return NativeMethods.sqlite3_column_count(statement);
		}

		public IntPtr sqlite3_column_database_name16(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_database_name16(statement, columnIndex);
		}

		public IntPtr sqlite3_column_decltype16(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_decltype16(statement, columnIndex);
		}

		public double sqlite3_column_double(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_double(statement, columnIndex);
		}

		public int sqlite3_column_int(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_int(statement, columnIndex);
		}

		public long sqlite3_column_int64(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_int64(statement, columnIndex);
		}

		public IntPtr sqlite3_column_name16(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_name16(statement, columnIndex);
		}

		public IntPtr sqlite3_column_origin_name16(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_origin_name16(statement, columnIndex);
		}

		public IntPtr sqlite3_column_table_name16(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_table_name16(statement, columnIndex);
		}

		public IntPtr sqlite3_column_text16(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_text16(statement, columnIndex);
		}

		public SQLiteDataType sqlite3_column_type(SQLiteStatement statement, int columnIndex)
		{
			return NativeMethods.sqlite3_column_type(statement, columnIndex);
		}


		public SQLiteResultCode sqlite3_errcode(SQLiteConnection connection)
		{
			return NativeMethods.sqlite3_errcode(connection);
		}

		public IntPtr sqlite3_errmsg16(SQLiteConnection connection)
		{
			return NativeMethods.sqlite3_errmsg16(connection);
		}

		public IntPtr sqlite3_errstr(SQLiteResultCode resultCode)
		{
			return NativeMethods.sqlite3_errstr(resultCode);
		}

		public IntPtr sqlite3_extended_errstr(SQLiteExtendedResultCode resultCode)
		{
			return NativeMethods.sqlite3_extended_errstr(resultCode);

		}

		public SQLiteExtendedResultCode sqlite3_extended_errcode(SQLiteConnection connection)
		{
			return NativeMethods.sqlite3_extended_errcode(connection);
		}

		public int sqlite3_extended_result_codes(SQLiteConnection connection, bool enableExtendedResultCodes)
		{
			return NativeMethods.sqlite3_extended_result_codes(connection, enableExtendedResultCodes);
		}

		public SQLiteResultCode sqlite3_finalize(IntPtr statementHandle)
		{
			return NativeMethods.sqlite3_finalize(statementHandle);
		}

		public SQLiteResultCode sqlite3_open_v2(string filename, out SQLiteConnection connection, SQLiteOpenFlags flags, string vfsModuleName)
		{
			return NativeMethods.sqlite3_open_v2(filename, out connection, flags, vfsModuleName);
		}

		public SQLiteResultCode sqlite3_prepare16_v2(SQLiteConnection connection, string sqlQuery, int sqlQueryByteLength, out SQLiteStatement statement, IntPtr doNotUse)
		{
			return NativeMethods.sqlite3_prepare16_v2(connection, sqlQuery, sqlQueryByteLength, out statement, doNotUse);
		}

		public SQLiteResultCode sqlite3_reset(SQLiteStatement statement)
		{
			return NativeMethods.sqlite3_reset(statement);
		}

		public SQLiteResultCode sqlite3_step(SQLiteStatement statement)
		{
			return NativeMethods.sqlite3_step(statement);
		}

		public SQLiteResultCode sqlite3_table_column_metadata(SQLiteConnection connection, string dbName, string tableName, string columnName, out IntPtr dataTypeNamePtr, out IntPtr collationSequenceNamePtr, out bool isNotNullable, out bool isPrimaryKey, out bool isAutoIncrement)
		{
			return NativeMethods.sqlite3_table_column_metadata(connection, dbName, tableName, columnName, out dataTypeNamePtr, out collationSequenceNamePtr, out isNotNullable, out isPrimaryKey, out isAutoIncrement);
		}

		#endregion ISQLiteApi Implementation

	}
}
