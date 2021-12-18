using System;

namespace Tasler.SQLite
{
	[Flags]
	public enum SQLiteOpenFlags
	{
		ReadOnly         = 0x00000001,
		ReadWrite        = 0x00000002,
		Create           = 0x00000004,
		Uri              = 0x00000040,
		Memory           = 0x00000080,
		NoMutex          = 0x00008000,
		FullMutex        = 0x00010000,
		SharedCache      = 0x00020000,
		PrivateCache     = 0x00040000,
		NoFollow         = 0x01000000,
		ExtendedResults  = 0x02000000,

		VfsDeleteOnClose = 0x00000008,
		VfsExclusive     = 0x00000010,
		VfsAutoProxy     = 0x00000020,
		VfsMainDb        = 0x00000100,
		VfsTemporaryDb   = 0x00000200,
		VfsTransientDb   = 0x00000400,
		VfsMainJournal   = 0x00000800,
		VfsTempJournal   = 0x00001000,
		VfsSubJournal    = 0x00002000,
		VfsMasterJournal = 0x00004000,
		VfsWriteAheadLog = 0x00080000
	}
}
