using System;
using System.Runtime.InteropServices;

namespace Tasler.SQLite
{
	public readonly struct SQLiteBlobSpan
	{
		internal unsafe SQLiteBlobSpan(void* pointer, int byteCount)
		{
			_pointer = pointer;
			_byteCount = byteCount;
		}

		public ReadOnlySpan<T> GetSpan<T>()
		{
			unsafe { return new ReadOnlySpan<T>(_pointer, _byteCount); }
		}

		public int GetLength<T>() => _byteCount / Marshal.SizeOf<T>();

		public IntPtr Pointer
		{
			get { unsafe { return new(_pointer); } }
		}

		public int ByteCount => _byteCount;

		private readonly unsafe void* _pointer;
		private readonly int _byteCount;
	}
}
