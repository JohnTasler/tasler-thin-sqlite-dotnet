using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Tasler.SQLite
{
	public abstract class SQLiteSafeHandle : SafeHandle
	{
		public SQLiteSafeHandle()
			: base(IntPtr.Zero, true)
		{
		}

		public override bool IsInvalid
		{
			[SecurityCritical]
			get { return this.handle == IntPtr.Zero; }
		}
	}
}
