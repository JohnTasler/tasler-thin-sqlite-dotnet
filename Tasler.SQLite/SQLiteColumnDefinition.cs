using System.Diagnostics;

namespace Tasler.SQLite
{

	[DebuggerDisplay("[{DatabaseName, nq}].[{TableName, nq}].[{Name, nq}] {DataTypeName, nq}")]
	public readonly record struct SQLiteColumnDefinition
	{
		public string Name                  { get; internal init; }
		public string TableName             { get; internal init; }
		public string DatabaseName          { get; internal init; }
		public string DataTypeName          { get; internal init; }
		public string CollationSequenceName { get; internal init; }
		public bool IsNotNullable           { get; internal init; }
		public bool IsPrimaryKey            { get; internal init; }
		public bool IsAutoIncrement         { get; internal init; }
	}
}
