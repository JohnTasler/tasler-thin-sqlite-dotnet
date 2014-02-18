
using System.Collections.Generic;

namespace Tasler.SQLite
{
	public class SQLiteRow
	{
		internal SQLiteRow(SQLiteStatement statement)
		{
			this.Statement = statement;
		}

		public SQLiteStatement Statement { get; private set; }

		private SQLiteColumn[] _columns;
		public IList<SQLiteColumn> Columns
		{
			get
			{
				lock (this.Statement._lockObject)
				{
					if (_columns == null)
					{
						var columnDefinitions = this.Statement.ColumnDefinitions;
						var columns = new SQLiteColumn[columnDefinitions.Count];

						for (var columnIndex = 0; columnIndex < columnDefinitions.Count; ++columnIndex)
							columns[columnIndex] = new SQLiteColumn(this, columnDefinitions[columnIndex], columnIndex);

						_columns = columns;
					}

					return _columns;
				}
			}
		}
	}
}
