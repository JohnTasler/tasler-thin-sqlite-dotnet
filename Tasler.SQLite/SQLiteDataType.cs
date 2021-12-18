
namespace Tasler.SQLite
{
	/// <summary>Every value in SQLite has one of these five fundamental datatypes</summary>
	public enum SQLiteDataType
	{
		/// <summary>A 64-bit signed integer.</summary>
		Integer = 1,

		/// <summary>A 64-bit IEEE floating point number.</summary>
		Float = 2,

		/// <summary>A string of text characters.</summary>
		Text = 3,

		/// <summary>A binaray large object.</summary>
		Blob = 4,

		/// <summary>A null value.</summary>
		Null = 5,
	}
}
