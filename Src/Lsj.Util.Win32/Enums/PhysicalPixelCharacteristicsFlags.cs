using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Physical Pixel Characteristics Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winddi/ns-winddi-gdiinfo"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum PhysicalPixelCharacteristicsFlags : uint
    {
        /// <summary>
        /// Display device physical pixel information is unknown.
        /// </summary>
        PPC_DEFAULT = 0x0,

        /// <summary>
        /// Display device physical pixel information is known but cannot be expressed as one of the given enumerations.
        /// The enumerations are currently applicable to an LCD-based monitor.
        /// The driver should set <see cref="GDIINFO.ulPhysicalPixelCharacteristics"/> to <see cref="PPC_UNDEFINED"/>
        /// when either of the following conditions is met.
        /// (This list is not comprehensive, but covers the most common conditions.)
        /// The driver has knowledge that the monitor is not an LCD device.
        /// The device is an LCD device but the resolution of the frame buffer
        /// is different from the native resolution of the physical display requiring scaling.
        /// That is, scaling is required because there is no longer a one-to-one correspondence between frame buffer pixels and device pixels.
        /// </summary>
        PPC_UNDEFINED = 0x1,

        /// <summary>
        /// Physical color fragments on the display device are arranged, from left to right, in columns of red, green, and blue color fragments. 
        /// </summary>
        PPC_RGB_ORDER_VERTICAL_STRIPES = 0x2,

        /// <summary>
        /// Physical color fragments on the display device are arranged, from left to right, in columns of blue, green, and red color fragments. 
        /// </summary>
        PPC_BGR_ORDER_VERTICAL_STRIPES = 0x3,

        /// <summary>
        /// Physical color fragments on the display device are arranged, from top to bottom, in rows of red, green, and blue color fragments. 
        /// </summary>
        PPC_RGB_ORDER_HORIZONTAL_STRIPES = 0x4,
        /// <summary>
        /// Physical color fragments on the display device are arranged, from top to bottom, in rows of blue, green, and red color fragments. 
        /// </summary>
        PPC_BGR_ORDER_HORIZONTAL_STRIPES = 0x5,
    }
}
