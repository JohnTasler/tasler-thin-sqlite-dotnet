using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasler.SQLite
{
	public sealed class SQLiteBlob : SQLiteSafeHandle
	{
		protected override bool ReleaseHandle()
		{
			return true;
		}
	}
}
