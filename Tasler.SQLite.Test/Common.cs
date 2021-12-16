using System.IO;
using Tasler.SQLite.Extensions;

namespace Tasler.SQLite.Test
{
	internal static class Common
	{
		public const string TestDatabaseFileName = "Tasler.SQLite.Test.sqlite";
		public const string StatementDeploymentSubPath = "Statements";

		public static readonly string TestDatabaseFullPathName = GetLocalFileFullPath(TestDatabaseFileName);

		public static string GetLocalFileFullPath(string fileName)
		{
			return Path.Combine(Path.GetTempPath(), fileName);
		}

		public static SQLiteStatement PrepareStatementText(this SQLiteConnection @this, string statementFileName)
		{
			return @this.PrepareStatementText(StatementDeploymentSubPath, statementFileName);
		}
	}
}
