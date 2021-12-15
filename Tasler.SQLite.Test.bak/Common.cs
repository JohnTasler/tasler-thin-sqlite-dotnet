using System;
using System.IO;
using Tasler.SQLite.Extensions;

namespace Tasler.SQLite.Test
{
	internal static class Common
	{
		public const string TestDatabaseFileName = "Tasler.SQLite.Test.sqlite";

		public static readonly string TestDatabaseFullPathName = GetLocalFileFullPath(TestDatabaseFileName);

		public static string GetLocalFileFullPath(string fileName)
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
		}

		public static SQLiteStatement PrepareStatementText(this SQLiteConnection @this, string statementFileName)
		{
			return @this.PrepareStatementText("Statements", statementFileName);
		}
	}
}
