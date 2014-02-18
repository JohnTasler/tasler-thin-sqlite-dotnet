
namespace Tasler.SQLite
{
	public enum SQLiteResultCode
	{
		/// <summary>Successful result</summary>
		Ok = 0,

		/// <summary>SQL error or missing database</summary>
		Error,

		/// <summary>Internal logic error in SQLite.</summary>
		Internal,

		/// <summary>Access permission denied.</summary>
		PermissionDenied,

		/// <summary>Callback routine requested an abort.</summary>
		Abort,

		/// <summary>The database file is locked.</summary>
		Busy,

		/// <summary>A table in the database is locked.</summary>
		Locked,

		/// <summary>A memory allocation failed.</summary>
		NoMemory,

		/// <summary>Attempt to write a readonly database.</summary>
		ReadOnly,

		/// <summary>Operation terminated by sqlite3_interrupt().</summary>
		Interrupt,

		/// <summary>Some kind of disk I/O error occurred.</summary>
		IoErr,

		/// <summary>The database disk image is malformed.</summary>
		Corrupt,

		/// <summary>Unknown opcode in sqlite3_file_control().</summary>
		NotFound,

		/// <summary>Insertion failed because database is full.</summary>
		Full,

		/// <summary>Unable to open the database file.</summary>
		CantOpen,

		/// <summary>Database lock protocol error.</summary>
		Protocol,

		/// <summary>Database is empty.</summary>
		Empty,

		/// <summary>The database schema changed.</summary>
		Schema,

		/// <summary>String or BLOB exceeds size limit.</summary>
		TooBig,

		/// <summary>Abort due to constraint violation.</summary>
		Constraint,

		/// <summary>Data type mismatch.</summary>
		Mismatch,

		/// <summary>Library used incorrectly.</summary>
		Misuse,

		/// <summary>Uses OS features not supported on host.</summary>
		NoLfs,

		/// <summary>Authorization denied.</summary>
		Auth,

		/// <summary>Auxiliary database format error.</summary>
		Format,

		/// <summary>2nd parameter to sqlite3_bind out of range.</summary>
		Range,

		/// <summary>File opened that is not a database file.</summary>
		NonDatabaseFile,

		/// <summary>Notifications from sqlite3_log().</summary>
		Notice,

		/// <summary>Warnings from sqlite3_log().</summary>
		Warning,

		/// <summary>sqlite3_step() has another row ready.</summary>
		Row = 100,

		/// <summary>sqlite3_step() has finished executing.</summary>
		Done = 101,
	}
}
