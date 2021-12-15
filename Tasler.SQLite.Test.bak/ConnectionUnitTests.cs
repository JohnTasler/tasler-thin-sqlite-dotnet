using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			var filePath = Common.GetLocalFileFullPath(Common.TestDatabaseFullPathName);
			ConsoleOutput.Instance.WriteLine($"filePath={filePath}", OutputLevel.Information);

			using (var connection = SQLiteConnection.Open(filePath))
			{
				Assert.IsNotNull(connection);
			}
		}
	}
}
