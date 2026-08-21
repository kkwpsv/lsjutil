using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Gdiplus;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="GdiplusStartupInput"/> structure holds a block of arguments that are required by the <see cref="GdiplusStartup"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/gdiplusinit/ns-gdiplusinit-gdiplusstartupinput"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="GdiplusStartupInput"/> structure provides a constructor that sets the <see cref="GdiplusVersion"/> member to 1,
    /// and allows you to specify values for the other three members.
    /// All of the constructor parameters are optional, so you can declare a variable of type <see cref="GdiplusStartupInput"/>
    /// without passing any arguments to the constructor, and all of the members will be initialized with appropriate default values.
    /// </para>
    /// <para>
    /// If you set the <see cref="SuppressBackgroundThread"/> member to <see cref="TRUE"/> in the input parameter of <see cref="GdiplusStartup"/>,
    /// then you must call the hook and unhook functions returned in the output parameter returned by that function.
    /// Call those functions before and after the application's main message loop; that is, a message loop that is active for the lifetime of GDI+.
    /// Call the hook function before the loop starts, and call the unhook function after the loop ends.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GdiplusStartupInput
    {
        /// <summary>
        /// Specifies the version of GDI+. Must be 1.
        /// </summary>
        public uint GdiplusVersion;

        /// <summary>
        /// Pointer to a callback function that GDI+ can call, on debug builds, for assertions and warnings.
        /// The default value is <see cref="NULL"/>.
        /// </summary>
        public nint DebugEventCallback;

        /// <summary>
        /// Boolean value that specifies whether to suppress the GDI+ background thread.
        /// If you set this member to <see cref="TRUE"/>, then <see cref="GdiplusStartup"/>
        /// returns (in its output parameter) a pointer to a hook function, and a pointer to an unhook function.
        /// You must call those functions appropriately to replace the background thread.
        /// If you don't want to be responsible for calling the hook and unhook functions, then set this member to <see cref="FALSE"/>.
        /// The default value is <see cref="FALSE"/>.
        /// </summary>
        public BOOL SuppressBackgroundThread;

        /// <summary>
        /// Boolean value that specifies whether you want GDI+ to suppress external image codecs.
        /// GDI+ version 1.0 doesn't support external image codecs, so this field is ignored.
        /// The default value is <see cref="FALSE"/>.
        /// </summary>
        public BOOL SuppressExternalCodecs;
    }
}
