using Lsj.Util.IL;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.Extensions.Memory
{
    /// <summary>
    /// Heap memory helper
    /// </summary>
    public static class HeapHelper
    {
        /// <summary>
        /// Alloc memory
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static nint AllocMemory(int size)
        {
            return Kernel32.HeapAlloc(Kernel32.GetProcessHeap(), 0, size);
        }

        /// <summary>
        /// Alloc memory for unmanaged struct
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="struct"></param>
        /// <returns></returns>
        public static unsafe nint AllocMemoryForUnmanagedStruct<T>(T @struct) where T : unmanaged
        {
            var size = SizeOf<T>();
            var addr = Kernel32.HeapAlloc(Kernel32.GetProcessHeap(), 0, size);
            Unsafe.CopyBlock((void*)addr, &@struct, (uint)size);
            return addr;
        }

        /// <summary>
        /// Free memory
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static bool FreeMemory(nint ptr)
        {
            return Kernel32.HeapFree(Kernel32.GetProcessHeap(), 0, ptr);
        }
    }
}
