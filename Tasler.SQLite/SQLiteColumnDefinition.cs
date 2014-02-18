
namespace Tasler.SQLite
{
	public class SQLiteColumnDefinition
	{
		public string Name                  { get; internal set; }
		public string TableName             { get; internal set; }
		public string DatabaseName          { get; internal set; }
		public string DataTypeName          { get; internal set; }
		public string CollationSequenceName { get; internal set; }
		public bool IsNotNullable           { get; internal set; }
		public bool IsPrimaryKey            { get; internal set; }
		public bool IsAutoIncrement         { get; internal set; }
	}
}
