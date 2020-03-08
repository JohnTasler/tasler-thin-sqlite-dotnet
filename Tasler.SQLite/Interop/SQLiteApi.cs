using System;

namespace Tasler.SQLite.Interop
{
	internal static class SQLiteApi
	{
		private static readonly ISQLiteApi ms_native;

		static SQLiteApi ( )
		{
			var architecture = KernelApi.GetSystemProcessorArchitecture ( );
			switch ( architecture )
			{
			case ProcessorArchitecture.X86:
				ms_native = new SQLiteApi32 ( );
				break;
			//case ProcessorArchitecture.X64:
			//    ms_native = new SQLiteApi64 ( );
			//    break;
			//case ProcessorArchitecture.Arm:
			//    ms_native = new SQLiteApiArm ( );
			//    break;
			default:
				throw new InvalidOperationException (
						"Application is running on an unrecognized processor architecture: " + architecture );
			}
		}

		internal static ISQLiteApi Native { get { return ms_native; } }

		internal delegate void MemoryReleaseCallback ( IntPtr pointer );
	}
}
