using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Tasler.SQLite.Interop;

namespace Tasler.SQLite
{
	[DebuggerDisplay("{GetValue()}, {DataType}, {Definition}")]
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
			return this.DataType switch
			{
				SQLiteDataType.Integer => this.GetInt64Value(),
				SQLiteDataType.Float => this.GetDoubleValue(),
				SQLiteDataType.Text => this.GetStringValue(),
				SQLiteDataType.Blob => this.GetBlobSpanValue(),
				_ => null,
			};
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

		public DateTime GetDateTimeValue()
		{
			return this.DataType switch
			{
				SQLiteDataType.Integer => DateTime.FromFileTimeUtc(GetInt64Value()),
				SQLiteDataType.Float => ConvertFromJulianDay(GetDoubleValue()),
				SQLiteDataType.Text => DateTime.Parse(GetStringValue()),
				_ => DateTime.MinValue,
			};
		}

		private static double ConvertToJulianDay(DateTime dateTime)
		{
			var dayNumber = (1461 * (dateTime.Year + 4800 + (dateTime.Month - 14) / 12)) / 4 + (367 * (dateTime.Month - 2 - 12 * ((dateTime.Month - 14) / 12))) / 12 - (3 * ((dateTime.Year + 4900 + (dateTime.Month - 14) / 12) / 100)) / 4 + dateTime.Day - 32075;
			var fraction = dateTime - dateTime.Date;
			return dayNumber + fraction.Ticks / 864_000_000_000d;
		}

		private static DateTime ConvertFromJulianDay(double julianDate)
		{
			const long y = 4716;
			const long j = 1401;
			const long m = 2;
			const long n = 12;
			const long r = 4;
			const long p = 1461;
			const long v = 3;
			const long u = 5;
			const long s = 153;
			const long w = 2;
			const long B = 274277;
			const long C = -38;

			long J = (long)Math.Floor(julianDate);
			long f = J + j + (((4 * J + B) / 146097) * 3) / 4 + C;
			long e = r * f + v;
			long g = (e % p) / r;
			long h = u * g + w;
			long D = (h % s) / u + 1;
			long M = (h / s + m) % n + 1;
			long Y = e / p - y + (n + m - M) / n;

			var date = new DateTime((int)Y, (int)M, (int)D);

			// Compute and add the fractional time
			var fraction = julianDate - Math.Floor(julianDate);
			var ticks = (long)Math.Floor(fraction * 864_000_000_000d);
			var timeSpan = TimeSpan.FromTicks(ticks);
			var dateTime = date + timeSpan;

			return dateTime;
		}
	}
}
