
namespace Tasler.SQLite
{
	public enum SQLiteDatabaseStatus
	{
		/// <summary>
		/// This parameter returns the number of lookaside memory slots currently checked out.
		/// </summary>
		LookasideUsed = 0,
		/// <summary>
		/// This parameter returns the approximate number of bytes of heap memory used by all pager caches
		/// associated with the database connection. The associated highwater mark is always 0.
		/// </summary>
		CacheUsed = 1,
		/// <summary>
		/// This parameter returns the approximate number of bytes of heap memory used to store the schema for all
		/// databases associated with the connection - main, temp, and any ATTACH-ed databases. The full amount of
		/// memory used by the schemas is reported, even if the schema memory is shared with other database
		/// connections due to shared cache mode being enabled. The associated highwater mark is always 0.
		/// </summary>
		SchemaUsed = 2,
		/// <summary>
		/// This parameter returns the approximate number of bytes of heap and lookaside memory used by all
		/// prepared statements associated with the database connection. The associated highwater mark is always 0.
		/// </summary>
		StatementUsed = 3,
		/// <summary>
		/// This parameter returns the number of malloc attempts that were satisfied using lookaside memory.
		/// Only the high-water value is meaningful; the current value is always zero.
		/// </summary>
		LookasideHit = 4,
		/// <summary>
		/// This parameter returns the number malloc attempts that might have been satisfied using lookaside memory
		/// but failed due to the amount of memory requested being larger than the lookaside slot size. Only the
		/// high-water value is meaningful; the current value is always zero.
		/// </summary>
		LookasideMissSize = 5,
		/// <summary>
		/// This parameter returns the number malloc attempts that might have been satisfied using lookaside memory
		/// but failed due to all lookaside memory already being in use. Only the high-water value is meaningful;
		/// the current value is always zero.
		/// </summary>
		LookasideMissFull = 6,
		/// <summary>
		/// This parameter returns the number of pager cache hits that have occurred. The associated highwater mark
		/// is always 0.
		/// </summary>
		CacheHit = 7,
		/// <summary>
		/// This parameter returns the number of pager cache misses that have occurred. The associated highwater
		/// mark is always 0.
		/// </summary>
		CacheMiss = 8,
		/// <summary>
		/// This parameter returns the number of dirty cache entries that have been written to disk. Specifically,
		/// the number of pages written to the wal file in wal mode databases, or the number of pages written to
		/// the database file in rollback mode databases. Any pages written as part of transaction rollback or
		/// database recovery operations are not included. If an IO or other error occurs while writing a page to
		/// disk, the effect on subsequent SQLITE_DBSTATUS_CACHE_WRITE requests is undefined. The associated
		/// highwater mark is always 0.
		/// </summary>
		CacheWrite = 9,
		/// <summary>
		/// This parameter returns zero for the current value if and only if all foreign key constraints
		/// (deferred or immediate) have been resolved. The highwater mark is always 0.
		/// </summary>
		DeferredForeignKeys = 10,
		/// <summary>
		/// This parameter is similar to DBSTATUS_CACHE_USED, except that if a pager cache is shared between two
		/// or more connections the bytes of heap memory used by that pager cache is divided evenly between the
		/// attached connections. In other words, if none of the pager caches associated with the database
		/// connection are shared, this request returns the same value as DBSTATUS_CACHE_USED. Or, if one or more
		/// or the pager caches are shared, the value returned by this call will be smaller than that returned by
		/// <see cref="CacheUsed"/>. The associated highwater mark is always 0.
		/// </summary>
		CacheUsedShared = 11,
		/// <summary>
		/// This parameter returns the number of dirty cache entries that have been written to disk in the middle
		/// of a transaction due to the page cache overflowing. Transactions are more efficient if they are
		/// written to disk all at once. When pages spill mid-transaction, that introduces additional overhead.
		/// This parameter can be used help identify inefficiencies that can be resolved by increasing the cache
		/// size.
		/// </summary>
		CacheSpill = 12,
	}
}
