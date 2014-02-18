using System;

namespace Tasler.SQLite.Interop
{
	internal interface ISQLiteApi
	{
		SQLiteResultCode sqlite3_bind_blob(
				SQLiteStatement statement,
				int parameterIndex,
				IntPtr value,
				int byteCount,
				SQLiteApi.MemoryReleaseCallback releaseCallback);

		SQLiteResultCode sqlite3_bind_double(
				SQLiteStatement statement,
				int parameterIndex,
				double value);

		SQLiteResultCode sqlite3_bind_int(
				SQLiteStatement statement,
				int parameterIndex,
				int value);

		SQLiteResultCode sqlite3_bind_int64(
				SQLiteStatement statement,
				int parameterIndex,
				long value);

		SQLiteResultCode sqlite3_bind_null(
				SQLiteStatement statement,
				int parameterIndex);

		SQLiteResultCode sqlite3_bind_text16(
				SQLiteStatement statement,
				int parameterIndex,
				IntPtr value,
				int byteCount,
				SQLiteApi.MemoryReleaseCallback releaseCallback);

		SQLiteResultCode sqlite3_bind_zeroblob(
				SQLiteStatement statement,
				int parameterIndex,
				int byteCount);

		int sqlite3_bind_parameter_count(
				SQLiteStatement statement);

		IntPtr sqlite3_bind_parameter_name(
				SQLiteStatement statement,
				int parameterIndex);

		int sqlite3_bind_parameter_index(
				SQLiteStatement statement,
				string parameterName);

		SQLiteResultCode sqlite3_clear_bindings(
				SQLiteStatement statement);

		SQLiteResultCode sqlite3_close_v2(
				IntPtr connectionHandle);

		IntPtr sqlite3_column_blob(
				SQLiteStatement statement,
				int columnIndex);

		int sqlite3_column_bytes(
				SQLiteStatement statement,
				int columnIndex);

		int sqlite3_column_count(
				SQLiteStatement statement);

		IntPtr sqlite3_column_database_name16(
				SQLiteStatement statement,
				int columnIndex);

		IntPtr sqlite3_column_decltype16(
				SQLiteStatement statement,
				int columnIndex);

		double sqlite3_column_double(
				SQLiteStatement statement,
				int columnIndex);

		int sqlite3_column_int(
				SQLiteStatement statement,
				int columnIndex);

		long sqlite3_column_int64(
				SQLiteStatement statement,
				int columnIndex);

		IntPtr sqlite3_column_name16(
				SQLiteStatement statement,
				int columnIndex);

		IntPtr sqlite3_column_origin_name16(
				SQLiteStatement statement,
				int columnIndex);

		IntPtr sqlite3_column_table_name16(
				SQLiteStatement statement,
				int columnIndex);

		IntPtr sqlite3_column_text16(
				SQLiteStatement statement,
				int columnIndex);

		SQLiteDataType sqlite3_column_type(
				SQLiteStatement statement,
				int columnIndex);

		SQLiteResultCode sqlite3_errcode(
				SQLiteConnection connection);

		IntPtr sqlite3_errmsg16(
				SQLiteConnection connection);

		IntPtr sqlite3_errstr(
				SQLiteResultCode resultCode);

		IntPtr sqlite3_extended_errstr(
				SQLiteExtendedResultCode resultCode);

		SQLiteExtendedResultCode sqlite3_extended_errcode(
				SQLiteConnection connection);

		int sqlite3_extended_result_codes(
				SQLiteConnection connection,
				bool enableExtendedResultCodes);

		SQLiteResultCode sqlite3_finalize(
				IntPtr statementHandle);

		SQLiteResultCode sqlite3_open_v2(
				string filename,
				out SQLiteConnection connection,
				SQLiteOpenFlags flags,
				string vfsModuleName);

		SQLiteResultCode sqlite3_prepare16_v2(
				SQLiteConnection connection,
				string sqlQuery,
				int sqlQueryByteLength,
				out SQLiteStatement statement,
				IntPtr reservedMustBeZero);

		SQLiteResultCode sqlite3_reset(
				SQLiteStatement statement);

		SQLiteResultCode sqlite3_step(
				SQLiteStatement statement);

		SQLiteResultCode sqlite3_table_column_metadata(
				SQLiteConnection connection,
				string dbName,
				string tableName,
				string columnName,
				out IntPtr dataTypeNamePtr,
				out IntPtr collationSequenceNamePtr,
				out bool isNotNullable,
				out bool isPrimaryKey,
				out bool isAutoIncrement);

	}
}
