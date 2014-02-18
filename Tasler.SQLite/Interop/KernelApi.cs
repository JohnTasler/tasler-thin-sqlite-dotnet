using System;
using System.Runtime.InteropServices;

namespace Tasler.SQLite.Interop
{
	internal static class KernelApi
	{
		internal static ProcessorArchitecture GetSystemProcessorArchitecture ( )
		{
			var systemInfo = new SYSTEM_INFO ( );
			NativeMethods.GetSystemInfo ( ref systemInfo );
			return systemInfo.wProcessorArchitecture;
		}

		internal static class NativeMethods
		{
			private const string ApiLib = "kernel32.dll";

			[DllImport ( ApiLib, SetLastError = true )]
			internal static extern void GetSystemInfo ( ref SYSTEM_INFO lpSystemInfo );
		}

		[StructLayout ( LayoutKind.Sequential )]
		internal struct SYSTEM_INFO
		{
			internal ProcessorArchitecture wProcessorArchitecture;
			internal short wReserved;
			internal int dwPageSize;
			internal IntPtr lpMinimumApplicationAddress;
			internal IntPtr lpMaximumApplicationAddress;
			internal IntPtr dwActiveProcessorMask;
			internal int dwNumberOfProcessors;
			internal int dwProcessorType;
			internal int dwAllocationGranularity;
			internal short wProcessorLevel;
			internal short wProcessorRevision;
		}
	}
}
