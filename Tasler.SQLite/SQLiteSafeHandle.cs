using System;
using System.Runtime.InteropServices;
using System.Security;
using Tasler.SQLite.Interop;

namespace Tasler.SQLite
{
	public abstract class SQLiteSafeHandle : SafeHandle
	{
		internal static readonly ISQLiteApi Native = SQLiteApi.Native;

		public SQLiteSafeHandle ( )
			: base ( IntPtr.Zero, true )
		{
		}

		public override bool IsInvalid
		{
			[SecurityCritical]
			get { return this.handle == IntPtr.Zero; }
		}
	}
}
