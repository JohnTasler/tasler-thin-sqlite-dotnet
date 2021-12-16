
namespace Tasler.SQLite
{
	public sealed class SQLiteConnectionException : SQLiteException
	{
		internal SQLiteConnectionException(SQLiteConnection connection)
			: base(
					connection.LastExtendedErrorMessage,
					connection.LastErrorMessage,
					connection.LastErrorCode,
					connection.LastExtendedErrorCode)
		{
		}
	}
}
