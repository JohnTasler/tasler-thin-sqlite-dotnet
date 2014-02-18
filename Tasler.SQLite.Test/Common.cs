using System.IO;
using Windows.ApplicationModel;
using Windows.Storage;

namespace Tasler.SQLite.Test
{
	internal static class Common
	{
		public const string testDatabaseFileName = "Tasler.SQLite.Test.sqlite";

		public static readonly string TestDatabaseFullPathName = GetLocalFileFullPath(testDatabaseFileName);

		public static string GetLocalFileFullPath(string fileName)
		{
			return Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
		}

		public static SQLiteStatement PrepareStatementText(this SQLiteConnection @this, string statementFileName)
		{
			return @this.PrepareStatement(Common.LoadStatementText(statementFileName));
		}

		public static string LoadStatementText(string statementFileName)
		{
			var relativePath = @"Statements\" + statementFileName;
			var openStreamTask = Package.Current.InstalledLocation.OpenStreamForReadAsync(relativePath);
			openStreamTask.Wait();

			using (var stream = openStreamTask.Result)
			using (var reader = new StreamReader(stream))
				return reader.ReadToEnd();
		}
	}
}
