using System;

namespace Tasler.SQLite
{
	public abstract class SQLiteException : Exception
	{
		internal SQLiteException(string extendedErrorMessage, string errorMessage, SQLiteResultCode errorCode, SQLiteExtendedResultCode extendedErrorCode)
			: base(extendedErrorMessage)
		{
			this.ErrorMessage = extendedErrorMessage;
			this.ErrorCode = errorCode;
			this.ExtendedErrorCode = extendedErrorCode;
		}

		public SQLiteResultCode ErrorCode { get; private set; }

		public SQLiteExtendedResultCode ExtendedErrorCode { get; private set; }

		public string ErrorMessage { get; private set; }
	}
}
