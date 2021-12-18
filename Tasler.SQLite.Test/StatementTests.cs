using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tasler.SQLite.Test
{
	[TestClass]
	public class StatementTests
	{
		[TestMethod]
		public void CreateTable()
		{
			using (var connection = SQLiteConnection.Open(Common.TestDatabaseFullPathName))
			{
				Assert.IsNotNull(connection);

				using (var statement = connection.PrepareStatementText("DropNamesTable.sql"))
				{
					statement.Execute();
					Assert.AreEqual(0, statement.ColumnDefinitions.Count);
				}

				using (var statement = connection.PrepareStatementText("CreateNamesTable.sql"))
				{
					statement.Execute();
					Assert.AreEqual(0, statement.ColumnDefinitions.Count);
				}

				var metadata = connection.GetTableColumnMetadata(null, "Names", "id");
				Assert.IsNull(metadata.DatabaseName);
				Assert.AreEqual("INTEGER", metadata.DataTypeName, true);
				Assert.AreEqual("BINARY", metadata.CollationSequenceName, true);
				Assert.IsFalse(metadata.IsNotNullable);
				Assert.IsTrue(metadata.IsPrimaryKey);
				Assert.IsTrue(metadata.IsAutoIncrement);

				metadata = connection.GetTableColumnMetadata("main", "Names", "firstName");
				Assert.AreEqual("main", metadata.DatabaseName, true);
				Assert.AreEqual("Names", metadata.TableName, true);
				Assert.AreEqual("firstName", metadata.Name, true);
				Assert.AreEqual("TEXT", metadata.DataTypeName, true);
				Assert.AreEqual("BINARY", metadata.CollationSequenceName, true);
				Assert.IsFalse(metadata.IsNotNullable);
				Assert.IsFalse(metadata.IsPrimaryKey);
				Assert.IsFalse(metadata.IsAutoIncrement);

				metadata = connection.GetTableColumnMetadata(null, "Names", "lastName");
				Assert.AreEqual("TEXT", metadata.DataTypeName, true);
				Assert.AreEqual("BINARY", metadata.CollationSequenceName, true);
				Assert.IsFalse(metadata.IsNotNullable);
				Assert.IsFalse(metadata.IsPrimaryKey);
				Assert.IsFalse(metadata.IsAutoIncrement);

				metadata = connection.GetTableColumnMetadata(null, "Names", "modified");
				Assert.AreEqual("DATETIME", metadata.DataTypeName, true);
				Assert.AreEqual("BINARY", metadata.CollationSequenceName, true);
				Assert.IsFalse(metadata.IsNotNullable);
				Assert.IsFalse(metadata.IsPrimaryKey);
				Assert.IsFalse(metadata.IsAutoIncrement);
			}
		}

		[TestMethod]
		public void InsertStaticValuesIntoTable()
		{
			using (var connection = SQLiteConnection.Open(Common.TestDatabaseFullPathName))
			{
				using (var statement = connection.PrepareStatementText("DropNamesTable.sql"))
					statement.Execute();

				using (var statement = connection.PrepareStatementText("CreateNamesTable.sql"))
					statement.Execute();

				using (var statement = connection.PrepareStatementText("InsertStaticValuesIntoTable.sql"))
					statement.Execute();
			}

			using (var connection = SQLiteConnection.Open(Common.TestDatabaseFullPathName))
			{
				using (var statement = connection.PrepareStatementText("SelectFromNamesTable.sql"))
				{
					var firstRow = statement.GetRows().FirstOrDefault();
					Assert.IsNotNull(firstRow, "No rows were returned from the SELECT statement. Expected at least 1.");
					Assert.AreEqual(4, firstRow.Columns.Count);
					Assert.AreEqual("John", firstRow.Columns[1].GetStringValue());
					Assert.AreEqual("Tasler", firstRow.Columns[2].GetStringValue());
					Assert.AreNotEqual(0, firstRow.Columns[3].GetDoubleValue());
					for (var index = 0; index < firstRow.Columns.Count; ++index)
					{
						var column = firstRow.Columns[index];
						Assert.AreEqual(index, column.Index);
						Assert.IsNotNull(column.Definition);
					}

					Assert.AreEqual("TEXT", firstRow.Columns[1].Definition.DataTypeName, true);
					Assert.AreEqual("TEXT", firstRow.Columns[2].Definition.DataTypeName, true);
					Assert.AreEqual("DATETIME", firstRow.Columns[3].Definition.DataTypeName, true);
				}
			}
		}

		[TestMethod]
		public void InsertBoundValuesIntoTable()
		{
			using (var connection = SQLiteConnection.Open(Common.TestDatabaseFullPathName))
			{
				using (var statement = connection.PrepareStatementText("DropNamesTable.sql"))
					statement.Execute();

				using (var statement = connection.PrepareStatementText("CreateNamesTable.sql"))
					statement.Execute();

				using (var statement = connection.PrepareStatementText("InsertBoundValuesIntoTable.sql"))
				{
					var insertRecords = new []
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
			//	using (var statement = connection.PrepareStatementText("SelectFromNamesTable.sql"))
			//	{
			//		var firstRow = statement.GetRows().FirstOrDefault();
			//		Assert.IsNotNull(firstRow, "No rows were returned from the SELECT statement. Expected 1.");
			//		Assert.AreEqual(3, firstRow.Columns.Count);
			//		Assert.AreEqual("John", firstRow.Columns[0].GetStringValue());
			//		Assert.AreEqual("Tasler", firstRow.Columns[1].GetStringValue());
			//		Assert.AreNotEqual(firstRow.Columns[2].GetDoubleValue(), 0);
			//		for (var index = 0; index < firstRow.Columns.Count; ++index)
			//		{
			//			var column = firstRow.Columns[index];
			//			Assert.AreEqual(index, column.Index);
			//			Assert.IsNotNull(column.Definition);
			//		}

			//		Assert.AreEqual("TEXT", firstRow.Columns[0].Definition.DataTypeName);
			//		Assert.AreEqual("TEXT", firstRow.Columns[1].Definition.DataTypeName);
			//		Assert.AreEqual("DATETIME", firstRow.Columns[2].Definition.DataTypeName);
			//	}
			//}
		}
	}
}
