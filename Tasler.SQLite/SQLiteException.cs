using System;
using Tasler.SQLite.Interop;

namespace Tasler.SQLite
{
	public abstract class SQLiteException : Exception
	{
		internal SQLiteException(SQLiteExtendedResultCode extendedErrorCode)
			: base(SQLiteConnection.GetErrorMessage(extendedErrorCode))
		{
			this.ExtendedErrorCode = extendedErrorCode;
		}

		public SQLiteResultCode ErrorCode => SQLiteApi.GetPrimaryResult(this.ExtendedErrorCode);

		public SQLiteExtendedResultCode ExtendedErrorCode { get; private set; }
	}
}
