using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tasler.SQLite.Interop
{
	internal class SQLiteApiArm : ISQLiteApi
	{
		internal static class NativeMethods
		{
			private const string ApiLib = @"Tasler.SQLite\Library\sqlite3-arm.dll";

			#region Methods

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			internal static extern
			SQLiteResultCode sqlite3_close_v2 ( SQLiteConnection connection );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			internal static extern
			SQLiteResultCode sqlite3_finalize ( SQLiteStatement statement );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			internal static extern
			SQLiteResultCode sqlite3_reset ( SQLiteStatement statement );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			[return: MarshalAs ( UnmanagedType.LPWStr )]
			internal static extern
			string sqlite3_column_database_name16 ( SQLiteStatement statement, int index );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			[return: MarshalAs ( UnmanagedType.LPWStr )]
			internal static extern
			string sqlite3_column_decltype16 ( SQLiteStatement statement, int index );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			[return: MarshalAs ( UnmanagedType.LPWStr )]
			internal static extern
			string sqlite3_column_name16 ( SQLiteStatement statement, int index );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			[return: MarshalAs ( UnmanagedType.LPWStr )]
			internal static extern
			string sqlite3_column_origin_name16 ( SQLiteStatement statement, int index );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			[return: MarshalAs ( UnmanagedType.LPWStr )]
			internal static extern
			string sqlite3_column_table_name16 ( SQLiteStatement statement, int index );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			[return: MarshalAs ( UnmanagedType.LPWStr )]
			internal static extern
			string sqlite3_column_text16 ( SQLiteStatement statement, int index );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			[return: MarshalAs ( UnmanagedType.LPWStr )]
			internal static extern
			string sqlite3_errmsg16 ( SQLiteConnection connection );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			internal static extern
			SQLiteResultCode sqlite3_open (
					[MarshalAs ( UnmanagedType.LPStr )] string filename,
					out SQLiteConnection connection );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			internal static extern
			SQLiteResultCode sqlite3_open16 (
					[MarshalAs ( UnmanagedType.LPWStr )] string filename,
					out SQLiteConnection connection );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			internal static extern
			SQLiteResultCode sqlite3_open_v2 (
					[MarshalAs ( UnmanagedType.LPStr )] string filename,
					out SQLiteConnection connection,
					SQLiteOpenFlags flags,
					[MarshalAs ( UnmanagedType.LPStr )] string vfsModuleName );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			internal static extern
			SQLiteResultCode sqlite3_prepare_v2 ( SQLiteConnection connection,
					[MarshalAs ( UnmanagedType.LPWStr )] string sqlQuery,
					int sqlQueryByteLength,
					out SQLiteStatement statement,
					out IntPtr doNotUse );

			[DllImport ( ApiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true )]
			internal static extern
			SQLiteResultCode sqlite3_table_column_metadata ( SQLiteConnection connection,
					[MarshalAs ( UnmanagedType.LPStr )] string dbName,
					[MarshalAs ( UnmanagedType.LPStr )] string tableName,
					[MarshalAs ( UnmanagedType.LPStr )] string columnName,
					[MarshalAs ( UnmanagedType.LPStr )] out StringBuilder dataTypeName,
					[MarshalAs ( UnmanagedType.LPStr )] out StringBuilder collationSequenceName,
					[MarshalAs ( UnmanagedType.Bool )] out bool isNotNullable,
					[MarshalAs ( UnmanagedType.Bool )] out bool isPrimaryKey,
					[MarshalAs ( UnmanagedType.Bool )] out bool isAutoIncrement );

			#endregion Methods
		}

	}
}
