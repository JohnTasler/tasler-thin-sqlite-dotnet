using System.Runtime.InteropServices;
using System.Text;
using Tasler.SQLite.Interop;

namespace Tasler.SQLite
{
	public sealed class SQLiteColumn
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

		public SQLiteDataType DataType => SQLiteApi.sqlite3_column_type(this.Row.Statement, this.Index);

		public object GetValue()
		{
			switch (this.DataType)
			{
				case SQLiteDataType.Integer:
					return this.GetInt64Value();

				case SQLiteDataType.Float:
					return this.GetDoubleValue();

				case SQLiteDataType.Text:
					return this.GetStringValue();

				case SQLiteDataType.Blob:
					return this.GetBlobSpanValue();

				case SQLiteDataType.Null:
				default:
					return null;
			}
		}

		public SQLiteBlobSpan GetBlobSpanValue()
		{
			var byteCount = SQLiteApi.sqlite3_column_bytes(Row.Statement, this.Index);
			unsafe
			{
				var blobPointer = SQLiteApi.sqlite3_column_blob(Row.Statement, this.Index);
				return new SQLiteBlobSpan(blobPointer, byteCount);
			}
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

		public override string ToString()
		{
			var builder = new StringBuilder();
			return $"{GetValue().ToString()}, {this.DataType}, {this.Definition}";
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
		//	var ticks = (long)Math.Floor(fraction * 864_000_000_000d);
		//	var timeSpan = TimeSpan.FromTicks(ticks);
		//	var dateTime = date + timeSpan;

		//	return dateTime;
		//}
	}
}
