
namespace Tasler.SQLite
{
	/// <summary>
	/// The counter values associated with the <see cref="SQLiteStatement.GetStatus"/> method.
	/// </summary>
	public enum SQLiteStatementStatus
	{
		/// <summary>
		/// This is the number of times that SQLite has stepped forward in a table as part of a full table scan.
		/// Large numbers for this counter may indicate opportunities for performance improvement through careful
		/// use of indices.
		/// </summary>
		FullscanStep = 1,

		/// <summary>
		/// This is the number of sort operations that have occurred. A non-zero value in this counter may indicate
		/// an opportunity to improvement performance through careful use of indices.
		/// </summary>
		Sort = 2,

		/// <summary>
		/// This is the number of rows inserted into transient indices that were created automatically in order to
		/// help joins run faster. A non-zero value in this counter may indicate an opportunity to improvement
		/// performance by adding permanent indices that do not need to be reinitialized each time the statement is run.
		/// </summary>
		AutoIndex = 3,

		/// <summary>
		/// This is the number of virtual machine operations executed by the prepared statement if that number is
		/// less than or equal to 2,147,483,647. The number of virtual machine operations can be used as a proxy
		/// for the total work done by the prepared statement. If the number of virtual machine operations exceeds
		/// 2,147,483,647 then the value returned by this statement status code is undefined.
		/// </summary>
		VirtualMachineStep = 4,

		/// <summary>
		/// This is the number of times that the prepare statement has been automatically regenerated due to
		/// schema changes or changes to bound parameters that might affect the query plan.
		/// </summary>
		RePrepare = 5,

		/// <summary>
		/// This is the number of times that the prepared statement has been run. A single "run" for the purposes
		/// of this counter is one or more calls to sqlite3_step() followed by a call to
		/// <see cref="SQLiteStatement.Reset"/>. The counter is incremented on the first <c>sqlite3_step()</c>
		/// call of each cycle.
		/// </summary>
		Run = 6,

		/// <summary>
		/// This is the approximate number of bytes of heap memory used to store the prepared statement. This
		/// value is not actually a counter, and so the <c>resetFlag</c> parameter to
		/// <see cref="SQLiteStatement.GetStatus"/> is ignored when the opcode is <c>MemoryUsed"</c>.
		/// </summary>
		MemoryUsed = 99,
	}
}
