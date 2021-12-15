using System.IO;
using System.Reflection;

namespace Tasler.SQLite.Extensions
{
	public static class SQLiteConnectionExtensions
	{
		public static SQLiteStatement PrepareStatementText(this SQLiteConnection @this, string subFolder, string statementFileName)
		{
			return @this.PrepareStatement(SQLiteConnectionExtensions.LoadStatementText(
				Path.GetDirectoryName(Assembly.GetCallingAssembly().Location),
				subFolder,
				statementFileName));
		}

		public static string LoadStatementText(string baseFolder, string subFolder, string statementFileName)
		{
			return File.ReadAllText(Path.Combine(baseFolder, subFolder, statementFileName));
		}
	}
}
