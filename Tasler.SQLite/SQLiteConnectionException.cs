
namespace Tasler.SQLite
{
	public sealed class SQLiteConnectionException : SQLiteException
	{
		internal SQLiteConnectionException(SQLiteExtendedResultCode extendedErrorCode)
			: base(extendedErrorCode)
		{
		}
	}
}
