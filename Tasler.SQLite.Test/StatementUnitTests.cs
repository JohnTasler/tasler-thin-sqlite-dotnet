using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tasler.SQLite.Test
{
	[TestClass]
	public class StatementUnitTests
	{
		[TestMethod]
		public void CreateTable()
		{
			using (var connection = SQLiteConnection.Open(Common.TestDatabaseFullPathName))
			{
				Assert.IsNotNull(connection);

				using (var statement = connection.PrepareStatementText("DropNamesTable.sqlite"))
					statement.Execute();

				using (var statement = connection.PrepareStatementText("CreateNamesTable.sqlite"))
				{
					statement.Execute();

					var columnDefinitions = statement.ColumnDefinitions;
					Assert.AreEqual(columnDefinitions.Count, 0);
				}

				var metadata = connection.GetTableColumnMetadata(null, "Names", "id");
				Assert.AreEqual(metadata.DataTypeName, "INTEGER");
				Assert.AreEqual(metadata.CollationSequenceName, "BINARY");
				Assert.AreEqual(metadata.IsNotNullable, false);
				Assert.AreEqual(metadata.IsPrimaryKey, true);
				Assert.AreEqual(metadata.IsAutoIncrement, true);

				metadata = connection.GetTableColumnMetadata(null, "Names", "firstName");
				Assert.AreEqual(metadata.DataTypeName, "TEXT");
				Assert.AreEqual(metadata.CollationSequenceName, "BINARY");
				Assert.AreEqual(metadata.IsNotNullable, false);
				Assert.AreEqual(metadata.IsPrimaryKey, false);
				Assert.AreEqual(metadata.IsAutoIncrement, false);

				metadata = connection.GetTableColumnMetadata(null, "Names", "lastName");
				Assert.AreEqual(metadata.DataTypeName, "TEXT");
				Assert.AreEqual(metadata.CollationSequenceName, "BINARY");
				Assert.AreEqual(metadata.IsNotNullable, false);
				Assert.AreEqual(metadata.IsPrimaryKey, false);
				Assert.AreEqual(metadata.IsAutoIncrement, false);

				metadata = connection.GetTableColumnMetadata(null, "Names", "modified");
				Assert.AreEqual(metadata.DataTypeName, "DATETIME");
				Assert.AreEqual(metadata.CollationSequenceName, "BINARY");
				Assert.AreEqual(metadata.IsNotNullable, false);
				Assert.AreEqual(metadata.IsPrimaryKey, false);
				Assert.AreEqual(metadata.IsAutoIncrement, false);
			}
		}

		[TestMethod]
		public void InsertStaticValuesIntoTable()
		{
			using (var connection = SQLiteConnection.Open(Common.TestDatabaseFullPathName))
			{
				using (var statement = connection.PrepareStatementText("DropNamesTable.sqlite"))
					statement.Execute();

				using (var statement = connection.PrepareStatementText("CreateNamesTable.sqlite"))
					statement.Execute();

				using (var statement = connection.PrepareStatementText("InsertStaticValuesIntoTable.sqlite"))
					statement.Execute();
			}

			using (var connection = SQLiteConnection.Open(Common.TestDatabaseFullPathName))
			{
				using (var statement = connection.PrepareStatementText("SelectFromNamesTable.sqlite"))
				{
					var firstRow = statement.GetRows().FirstOrDefault();
					Assert.IsNotNull(firstRow, "No rows were returned from the SELECT statement. Expected 1.");
					Assert.AreEqual(firstRow.Columns.Count, 3);
					Assert.AreEqual(firstRow.Columns[0].GetStringValue(), "John");
					Assert.AreEqual(firstRow.Columns[1].GetStringValue(), "Tasler");
					Assert.AreNotEqual(firstRow.Columns[2].GetDoubleValue(), 0);
					for (var index = 0; index < firstRow.Columns.Count; ++index)
					{
						var column = firstRow.Columns[index];
						Assert.AreEqual(column.Index, index);
						Assert.IsNotNull(column.Definition);
					}

					Assert.AreEqual(firstRow.Columns[0].Definition.DataTypeName, "TEXT");
					Assert.AreEqual(firstRow.Columns[1].Definition.DataTypeName, "TEXT");
					Assert.AreEqual(firstRow.Columns[2].Definition.DataTypeName, "DATETIME");
				}
			}
		}

		[TestMethod]
		public void InsertBoundValuesIntoTable()
		{
			using (var connection = SQLiteConnection.Open(Common.TestDatabaseFullPathName))
			{
				using (var statement = connection.PrepareStatementText("DropNamesTable.sqlite"))
					statement.Execute();

				using (var statement = connection.PrepareStatementText("CreateNamesTable.sqlite"))
					statement.Execute();

				using (var statement = connection.PrepareStatementText("InsertBoundValuesIntoTable.sqlite"))
				{
					var insertRecords = new[]
					{
						new { FirstName = "Keith"  , LastName = "Richards" },
						new { FirstName = "Michael", LastName = "Jackson"  },
						new { FirstName = "Elvis"  , LastName = "Presley"  },
						new { FirstName = "Jimmy"  , LastName = "Page"     },
					};

					foreach (var insertRecord in insertRecords)
					{
						statement.Reset();
						statement.BindTextParameter("@firstName", insertRecord.FirstName);
						statement.BindTextParameter("@lastName" , insertRecord.LastName);
						statement.Execute();
					}
				}
			}

			//using (var connection = SQLiteConnection.Open(Common.TestDatabaseFullPathName))
			//{
			//	using (var statement = connection.PrepareStatementText("SelectFromNamesTable.sqlite"))
			//	{
			//		var firstRow = statement.GetRows().FirstOrDefault();
			//		Assert.IsNotNull(firstRow, "No rows were returned from the SELECT statement. Expected 1.");
			//		Assert.AreEqual(firstRow.Columns.Count, 3);
			//		Assert.AreEqual(firstRow.Columns[0].GetStringValue(), "John");
			//		Assert.AreEqual(firstRow.Columns[1].GetStringValue(), "Tasler");
			//		Assert.AreNotEqual(firstRow.Columns[2].GetDoubleValue(), 0);
			//		for (var index = 0; index < firstRow.Columns.Count; ++index)
			//		{
			//			var column = firstRow.Columns[index];
			//			Assert.AreEqual(column.Index, index);
			//			Assert.IsNotNull(column.Definition);
			//		}

			//		Assert.AreEqual(firstRow.Columns[0].Definition.DataTypeName, "TEXT");
			//		Assert.AreEqual(firstRow.Columns[1].Definition.DataTypeName, "TEXT");
			//		Assert.AreEqual(firstRow.Columns[2].Definition.DataTypeName, "DATETIME");
			//	}
			//}
		}
	}
}
