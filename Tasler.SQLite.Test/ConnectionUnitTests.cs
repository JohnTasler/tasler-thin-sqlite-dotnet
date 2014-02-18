using System.IO;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Storage;

namespace Tasler.SQLite.Test
{
	[TestClass]
	public class ConnectionUnitTests
	{
		[TestMethod]
		public void CreateAndCloseMemoryDb()
		{
			using (var connection = SQLiteConnection.Open(":memory:"))
			{
				Assert.IsNotNull(connection);
			}
		}

		[TestMethod]
		public void CreateAndCloseFileDb()
		{
			var filePath = GetLocalFileFullPath(Common.TestDatabaseFullPathName);
			Logger.LogMessage("filePath={0}", filePath);

			using (var connection = SQLiteConnection.Open(filePath))
			{
				Assert.IsNotNull(connection);
			}
		}

		internal static string GetLocalFileFullPath(string fileName)
		{
			return Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
		}
	}
}
