using System;
using System.Runtime.InteropServices;
using Tasler.SQLite.Interop;

namespace Tasler.SQLite
{
	public class SQLiteColumn
	{
		internal SQLiteColumn(SQLiteRow row, SQLiteColumnDefinition definition, int index)
		{
			this.Definition = definition;
			this.Row = row;
			this.Index = index;
		}

		public SQLiteColumnDefinition Definition { get; private set; }

		public SQLiteRow Row { get; private set; }

		public int Index { get; private set; }

		public object GetValue()
		{
			var dataTypeName = this.Definition.DataTypeName.ToUpper();

			if (dataTypeName.Contains("INT"))
			{
				var value = this.GetInt64Value();
				return value <= int.MaxValue ? (int)value : value;
			}

			if (dataTypeName.Contains("CHAR") || dataTypeName.Contains("CLOB") || dataTypeName.Contains("TEXT"))
			{
				return this.GetStringValue();
			}

			if (dataTypeName.Contains("BLOB") || dataTypeName == string.Empty)
			{
				return this.GetBlobValue();
			}

			if (dataTypeName.Contains("REAL") || dataTypeName.Contains("FLOA") || dataTypeName.Contains("DOUB"))
			{
				return this.GetDoubleValue();
			}

			var doubleValue = this.GetDoubleValue();
			if (Math.Floor(doubleValue) != doubleValue)
			{
				return doubleValue;
			}

			var longValue = this.GetInt64Value();
			return longValue <= int.MaxValue ? (int)longValue : longValue;
		}

		public byte[] GetBlobValue()
		{
			var byteCount = SQLiteApi.sqlite3_column_bytes(Row.Statement, this.Index);
			var blob = SQLiteApi.sqlite3_column_blob(Row.Statement, this.Index);
			var value = new byte[byteCount];
			Marshal.Copy(blob, value, 0, byteCount);
			return value;
		}

		public double GetDoubleValue()
		{
			return SQLiteApi.sqlite3_column_double(Row.Statement, this.Index);
		}

		public int GetInt32Value()
		{
			return SQLiteApi.sqlite3_column_int(Row.Statement, this.Index);
		}

		public long GetInt64Value()
		{
			return SQLiteApi.sqlite3_column_int64(Row.Statement, this.Index);
		}

		public string GetStringValue()
		{
			return Marshal.PtrToStringUni(SQLiteApi.sqlite3_column_text16(Row.Statement, this.Index));
		}

		public bool GetBooleanValue()
		{
			var value = GetInt64Value();
			return value != 0;
		}

		//public DateTime GetDateTimeValue()
		//{
		//	var value = GetDoubleValue();
		//}

		//private DateTime ConvertFromJulianDate(double julianDate)
		//{
		//	long y = 4716;
		//	long j = 1401;
		//	long m = 2;
		//	long n = 12;
		//	long r = 4;
		//	long p = 1461;
		//	long v = 3;
		//	long u = 5;
		//	long s = 153;
		//	long w = 2;
		//	long B = 274277;
		//	long C = -38;

		//	long J = (long)Math.Floor(julianDate);
		//	long f = J + j + (((4 * J + B) / 146097) * 3) / 4 + C;
		//	long e = r * f + v;
		//	long g = (e % p) / r;
		//	long h = u * g + w;
		//	long D = (h % s) / u + 1;
		//	long M = (h / s + m) % n + 1;
		//	long Y = e / p - y + (n + m - M) / n;

		//	var date = new DateTime((int)Y, (int)M, (int)D);

		//	// Compute and add the fractional time
		//	var fraction = julianDate - Math.Floor(julianDate);
		//	var ticks = (long)Math.Floor(fraction * 864000000000d);
		//	var timeSpan = TimeSpan.FromTicks(ticks);
		//	var dateTime = date + timeSpan;

		//	return dateTime;
		//}
	}
}
