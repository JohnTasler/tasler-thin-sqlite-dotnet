
using System.Text;

namespace Tasler.SQLite
{
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

		public override string ToString()
		{
			var builder = new StringBuilder();
			if (DatabaseName != null)
				builder.Append($"[{this.DatabaseName}].");
			if (TableName != null)
				builder.Append($"[{this.TableName}].");
			if (Name != null)
				builder.Append($"[{this.Name}].");
			builder.Append($" AS {this.DataTypeName}");

			return builder.ToString();
		}

	}
}
