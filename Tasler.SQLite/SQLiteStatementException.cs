
namespace Tasler.SQLite
{
	public sealed class SQLiteStatementException : SQLiteException
	{
		internal SQLiteStatementException(SQLiteExtendedResultCode extendedResultCode)
			: base(extendedResultCode)
		{
		}
	}
}
