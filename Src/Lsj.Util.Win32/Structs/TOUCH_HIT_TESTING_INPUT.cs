using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the touch contact area reported by the touch digitizer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-touch_hit_testing_input"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TOUCH_HIT_TESTING_INPUT
    {
        /// <summary>
        /// The ID of the pointer.
        /// You cannot pass this value to the input message process
        /// and retrieve additional pointer info through <see cref="GetPointerInfo"/>.
        /// </summary>
        public UINT32 pointerId;

        /// <summary>
        /// The screen coordinates of the touch point that the touch digitizer reports.
        /// </summary>
        public POINT point;

        /// <summary>
        /// <para>
        /// The bounding rectangle of the touch contact area.
        /// Valid touch targets are identified and scored based on this bounding box.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This bounding box may differ from the contact area that the digitizer reports when:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The digitizer reports a touch contact area that's outside the maximum or minimum size threshold
        /// that's recognized by Touch Hit Testing.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A portion of the touch contact area is occluded by another object that's higher in the z-order.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public RECT boundingBox;

        /// <summary>
        /// The touch contact area within a specific targeted window
        /// that's not occluded by other objects that are higher in the z-order.
        /// Any area that's occluded by another object is an invalid target.
        /// </summary>
        public RECT nonOccludedBoundingBox;

        /// <summary>
        /// The orientation of the touch contact area.
        /// </summary>
        public UINT32 orientation;
    }
}
