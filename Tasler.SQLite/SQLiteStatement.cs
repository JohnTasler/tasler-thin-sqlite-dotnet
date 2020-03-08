using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tasler.SQLite
{
	public class SQLiteStatement : SQLiteSafeHandle
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
						var columnCount = Native.sqlite3_column_count(this);
						var columnDefinitions = new SQLiteColumnDefinition[columnCount];
						for (var columnIndex = 0; columnIndex < columnCount; ++columnIndex)
						{
							var databaseName = Marshal.PtrToStringUni(Native.sqlite3_column_database_name16(this, columnIndex));
							var tableName = Marshal.PtrToStringUni(Native.sqlite3_column_table_name16(this, columnIndex));
							var originName = Marshal.PtrToStringUni(Native.sqlite3_column_origin_name16(this, columnIndex));

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
				throw new ArgumentNullException("parameterName");

			var parameterIndex = Native.sqlite3_bind_parameter_index(this, parameterName);
			if (parameterIndex == 0)
				throw new ArgumentException("The SQLiteStatement has no matching parameter name: " + parameterName, "parameterName");

			return parameterIndex;
		}

		public void BindTextParameter(string parameterName, string value)
		{
			this.BindTextParameter(GetParameterNameIndex(parameterName), value);
		}

		public void BindTextParameter(int parameterIndex, string value)
		{
			value = value ?? string.Empty;
			var pointer = Marshal.StringToCoTaskMemUni(value);
			var byteCount = value.Length * sizeof(char);
			var result = Native.sqlite3_bind_text16(this, parameterIndex, pointer, byteCount, new IntPtr(-1));
			Marshal.FreeCoTaskMem(pointer);
			ThrowOnError(result);
		}

		public SQLiteConnection Connection { get; internal set; }

		public void Execute()
		{
			GetRows().FirstOrDefault();
		}

		public IEnumerable<SQLiteRow> GetRows()
		{
			SQLiteResultCode result = SQLiteResultCode.Ok; //Native.sqlite3_reset(this);
			lock (_lockObject)
				_columnDefinitions = null;

			while (result != SQLiteResultCode.Done)
			{
				lock (_lockObject)
					result = Native.sqlite3_step(this);

				if (result == SQLiteResultCode.Row)
				{
					var row = new SQLiteRow(this);
					yield return row;
				}
				else if (result == SQLiteResultCode.Busy)
				{
					// TODO: Some retry logic
					// Thread.Sleep(10)
				}
				else if (result != SQLiteResultCode.Done)
				{
					ThrowOnError(result);
				}
			}
		}

		public void Reset()
		{
			var result = Native.sqlite3_reset(this);
			ThrowOnError(result);
		}

		protected override bool ReleaseHandle()
		{
			var errorCode = Native.sqlite3_finalize(this.handle);
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
