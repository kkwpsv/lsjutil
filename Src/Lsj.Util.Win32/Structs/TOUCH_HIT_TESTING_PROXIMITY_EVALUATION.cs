using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the hit test score that indicates whether the object is the likely target of the touch contact area,
    /// relative to other objects that intersect the touch contact area.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-touch_hit_testing_proximity_evaluation"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="EvaluateProximityToRect"/> or <see cref="EvaluateProximityToPolygon"/> function returns the values.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TOUCH_HIT_TESTING_PROXIMITY_EVALUATION
    {
        /// <summary>
        /// The score, compared to the other objects that intersect the touch contact area.
        /// </summary>
        public UINT16 score;

        /// <summary>
        /// The adjusted touch point that hits the closest object that's identified by the value of <see cref="score"/>.
        /// </summary>
        public POINT adjustedPoint;
    }
}
