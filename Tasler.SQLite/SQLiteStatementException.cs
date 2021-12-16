
namespace Tasler.SQLite
{
	public sealed class SQLiteStatementException : SQLiteException
	{
		internal SQLiteStatementException(SQLiteStatement statement)
			: base(
				statement.Connection.LastExtendedErrorMessage,
				statement.Connection.LastErrorMessage,
				statement.Connection.LastErrorCode,
				statement.Connection.LastExtendedErrorCode)
		{
		}
	}
}
