using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.BaseTypes.HBITMAP;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BitmapCompressions;
using static Lsj.Util.Win32.Enums.CreateDIBitmapFlags;
using static Lsj.Util.Win32.Enums.DIBColorTableUsages;
using static Lsj.Util.Win32.Enums.EscapeFunctions;
using static Lsj.Util.Win32.Enums.ICMModes;
using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.Enums.RasterCapabilities;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.RasterOps;
using static Lsj.Util.Win32.Enums.StretchBltModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.DeviceCapIndexes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Msimg32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CreateBitmap"/> function creates a bitmap
        /// with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createbitmap"/>
        /// </para>
        /// </summary>
        /// <param name="nWidth">
        /// The bitmap width, in pixels.
        /// </param>
        /// <param name="nHeight">
        /// The bitmap height, in pixels.
        /// </param>
        /// <param name="nPlanes">
        /// The number of color planes used by the device.
        /// </param>
        /// <param name="nBitCount">
        /// The number of bits required to identify the color of a single pixel.
        /// </param>
        /// <param name="lpBits">
        /// <para>
        /// A pointer to an array of color data used to set the colors in a rectangle of pixels.
        /// Each scan line in the rectangle must be word aligned
        /// (scan lines that are not word aligned must be padded with zeros).
        /// The buffer size expected, cj, can be calculated using the formula:
        /// </para>
        /// <code>
        /// cj = (((nWidth * nPlanes * nBitCount + 15) &gt;&gt; 4) &lt;&lt; 1) * nHeight;
        /// </code>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, then the contents of the new bitmap are undefined.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to a bitmap.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// This function can return the following value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_BITMAP"/>
        /// </term>
        /// <term>
        /// The calculated size of the bitmap is less than zero.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateBitmap"/> function creates a device-dependent bitmap.
        /// </para>
        /// <para>
        /// After a bitmap is created, it can be selected into a device context by calling the <see cref="SelectObject"/> function.
        /// However, the bitmap can only be selected into a device context if the bitmap and the DC have the same format.
        /// </para>
        /// <para>
        /// The <see cref="CreateBitmap"/> function can be used to create color bitmaps.
        /// However, for performance reasons applications should use <see cref="CreateBitmap"/> to create monochrome bitmaps
        /// and <see cref="CreateCompatibleBitmap"/> to create color bitmaps.
        /// Whenever a color bitmap returned from <see cref="CreateBitmap"/> is selected into a device context,
        /// the system checks that the bitmap matches the format of the device context it is being selected into.
        /// Because <see cref="CreateCompatibleBitmap"/> takes a device context,
        /// it returns a bitmap that has the same format as the specified device context.
        /// Thus, subsequent calls to <see cref="SelectObject"/> are faster with a color bitmap
        /// from <see cref="CreateCompatibleBitmap"/> than with a color bitmap returned from <see cref="CreateBitmap"/>.
        /// </para>
        /// <para>
        /// If the bitmap is monochrome, zeros represent the foreground color 
        /// and ones represent the background color for the destination device context.
        /// </para>
        /// <para>
        /// If an application sets the <paramref name="nWidth"/> or <paramref name="nHeight"/> parameters to zero,
        /// <see cref="CreateBitmap"/> returns the handle to a 1-by-1 pixel, monochrome bitmap.
        /// </para>
        /// <para>
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateBitmap", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateBitmap([In] int nWidth, [In] int nHeight, [In] UINT nPlanes, [In] UINT nBitCount, [In] IntPtr lpBits);

        /// <summary>
        /// <para>
        /// The <see cref="CreateBitmapIndirect"/> function creates a bitmap
        /// with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createbitmapindirect"/>
        /// </para>
        /// </summary>
        /// <param name="pbm">
        /// A pointer to a <see cref="BITMAP"/> structure that contains information about the bitmap.
        /// If an application sets the <see cref="BITMAP.bmWidth"/> or <see cref="BITMAP.bmHeight"/> members to zero,
        /// <see cref="CreateBitmapIndirect"/> returns the handle to a 1-by-1 pixel, monochrome bitmap.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the bitmap.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// This function can return the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// </term>
        /// <term>
        /// The bitmap is too big for memory to be allocated.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateBitmapIndirect"/> function creates a device-dependent bitmap.
        /// </para>
        /// <para>
        /// After a bitmap is created, it can be selected into a device context by calling the <see cref="SelectObject"/> function.
        /// However, the bitmap can only be selected into a device context if the bitmap and the DC have the same format.
        /// </para>
        /// <para>
        /// While the <see cref="CreateBitmapIndirect"/> function can be used to create color bitmaps,
        /// for performance reasons applications should use <see cref="CreateBitmapIndirect"/> to create monochrome bitmaps
        /// and <see cref="CreateCompatibleBitmap"/> to create color bitmaps.
        /// Whenever a color bitmap from <see cref="CreateBitmapIndirect"/> is selected into a device context,
        /// the system must ensure that the bitmap matches the format of the device context it is being selected into.
        /// Because <see cref="CreateCompatibleBitmap"/> takes a device context,
        /// it returns a bitmap that has the same format as the specified device context.
        /// Thus, subsequent calls to <see cref="SelectObject"/> are faster
        /// with a color bitmap from <see cref="CreateCompatibleBitmap"/> than
        /// with a color bitmap returned from <see cref="CreateBitmapIndirect"/>.
        /// </para>
        /// <para>
        /// If the bitmap is monochrome, zeros represent the foreground color
        /// and ones represent the background color for the destination device context.
        /// </para>
        /// <para>
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateBitmapIndirect", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateBitmapIndirect([In] in BITMAP pbm);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleBitmap"/> function creates a bitmap
        /// compatible with the device that is associated with the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createcompatiblebitmap"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="nWidth">
        /// The bitmap width, in pixels.
        /// </param>
        /// <param name="nHeight">
        /// The bitmap height, in pixels.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The color format of the bitmap created by the <see cref="CreateCompatibleBitmap"/> function
        /// matches the color format of the device identified by the hdc parameter.
        /// This bitmap can be selected into any memory device context that is compatible with the original device.
        /// </para>
        /// <para>
        /// Because memory device contexts allow both color and monochrome bitmaps,
        /// the format of the bitmap returned by the <see cref="CreateCompatibleBitmap"/> function
        /// differs when the specified device context is a memory device context.
        /// However, a compatible bitmap that was created for a nonmemory device context
        /// always possesses the same color format and uses the same color palette as the specified device context.
        /// </para>
        /// <para>
        /// Note: When a memory device context is created, it initially has a 1-by-1 monochrome bitmap selected into it.
        /// If this memory device context is used in <see cref="CreateCompatibleBitmap"/>,
        /// the bitmap that is created is a monochrome bitmap.
        /// To create a color bitmap, use the <see cref="HDC"/> that was used to create the memory device context,
        /// as shown in the following code:
        /// </para>
        /// <code>
        /// HDC memDC = CreateCompatibleDC ( hDC );
        /// HBITMAP memBM = CreateCompatibleBitmap(hDC, nWidth, nHeight);
        /// SelectObject(memDC, memBM );
        /// </code>
        /// <para>
        /// If an application sets the <paramref name="nWidth"/> or <paramref name="nHeight"/> parameters to zero,
        /// <see cref="CreateCompatibleBitmap"/> returns the handle to a 1-by-1 pixel, monochrome bitmap.
        /// </para>
        /// <para>
        /// If a DIB section, which is a bitmap created by the <see cref="CreateDIBSection"/> function,
        /// is selected into the device context identified by the hdc parameter,
        /// <see cref="CreateCompatibleBitmap"/> creates a DIB section.
        /// </para>
        /// <para>
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateCompatibleBitmap([In] HDC hdc, [In] int nWidth, [In] int nHeight);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDIBitmap"/> function creates a compatible bitmap (DDB)
        /// from a DIB and, optionally, sets the bitmap bits.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdibitmap"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="pbmih">
        /// <para>
        /// A pointer to a bitmap information header structure, <see cref="BITMAPV5HEADER"/>.
        /// </para>
        /// <para>
        /// If <paramref name="flInit"/> is <see cref="CBM_INIT"/>,
        /// the function uses the bitmap information header structure
        /// to obtain the desired width and height of the bitmap as well as other information.
        /// Note that a positive value for the height indicates a bottom-up DIB
        /// while a negative value for the height indicates a top-down DIB.
        /// Calling <see cref="CreateDIBitmap"/> with <paramref name="flInit"/> as <see cref="CBM_INIT"/>
        /// is equivalent to calling the <see cref="CreateCompatibleBitmap"/> function
        /// to create a DDB in the format of the device
        /// and then calling the <see cref="SetDIBits"/> function to translate the DIB bits to the DDB.
        /// </para>
        /// </param>
        /// <param name="flInit">
        /// <para>
        /// Specifies how the system initializes the bitmap bits.
        /// The following value is defined.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CBM_INIT"/>
        /// </term>
        /// <term>
        /// <para>
        /// If this flag is set, the system uses the data pointed to by the <paramref name="pjBits"/>
        /// and <paramref name="pbmi"/> parameters to initialize the bitmap bits.
        /// </para>
        /// <para>
        /// If this flag is clear, the data pointed to by those parameters is not used.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="flInit"/> is zero, the system does not initialize the bitmap bits.
        /// </para>
        /// </param>
        /// <param name="pjBits">
        /// A pointer to an array of bytes containing the initial bitmap data.
        /// The format of the data depends on the <see cref="BITMAPINFOHEADER.biBitCount"/> member 
        /// of the <see cref="BITMAPINFO"/> structure to which the <paramref name="pbmi"/> parameter points.
        /// </param>
        /// <param name="pbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure
        /// that describes the dimensions and color format of the array
        /// pointed to by the <paramref name="pjBits"/> parameter.
        /// </param>
        /// <param name="iUsage">
        /// <para>
        /// Specifies whether the <see cref="BITMAPINFO.bmiColors"/> member
        /// of the <see cref="BITMAPINFO"/> structure was initialized and,
        /// if so, whether <see cref="BITMAPINFO.bmiColors"/> contains explicit red, green, blue (RGB) values or palette indexes.
        /// The <paramref name="iUsage"/> parameter must be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DIB_PAL_COLORS"/>
        /// </term>
        /// <term>
        /// A color table is provided and consists of an array of 16-bit indexes
        /// into the logical palette of the device context into which the bitmap is to be selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DIB_RGB_COLORS"/>
        /// </term>
        /// <term>
        /// A color table is provided and contains literal RGB values.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the compatible bitmap.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The DDB that is created will be whatever bit depth your reference DC is.
        /// To create a bitmap that is of different bit depth, use <see cref="CreateDIBSection"/>.
        /// </para>
        /// <para>
        /// For a device to reach optimal bitmap-drawing speed, specify <paramref name="flInit"/> as <see cref="CBM_INIT"/>.
        /// Then, use the same color depth DIB as the video mode.
        /// When the video is running 4- or 8-bpp, use <see cref="DIB_PAL_COLORS"/>.
        /// </para>
        /// <para>
        /// The CBM_CREATDIB flag for the <paramref name="flInit"/> parameter is no longer supported.
        /// </para>
        /// <para>
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </para>
        /// <para>
        /// ICM: No color management is performed.
        /// The contents of the resulting bitmap are not color matched after the bitmap has been created.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDIBitmap", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateDIBitmap([In] HDC hdc, [In] in BITMAPINFOHEADER pbmih, [In] CreateDIBitmapFlags flInit,
            [In] IntPtr pjBits, [In] in BITMAPINFO pbmi, [In] UINT iUsage);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDIBSection"/> function creates a DIB that applications can write to directly.
        /// The function gives you a pointer to the location of the bitmap bit values.
        /// You can supply a handle to a file-mapping object that the function will use to create the bitmap,
        /// or you can let the system allocate the memory for the bitmap.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdibsection"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// If the value of <paramref name="usage"/> is <see cref="DIB_PAL_COLORS"/>,
        /// the function uses this device context's logical palette to initialize the DIB colors.
        /// </param>
        /// <param name="pbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure
        /// that specifies various attributes of the DIB, including the bitmap dimensions and colors.
        /// </param>
        /// <param name="usage">
        /// <para>
        /// The type of data contained in the <see cref="BITMAPINFO.bmiColors"/> array member
        /// of the <see cref="BITMAPINFO"/> structure pointed to by <paramref name="pbmi"/>
        /// (either logical palette indexes or literal RGB values).
        /// The following values are defined.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DIB_PAL_COLORS"/>
        /// </term>
        /// <term>
        /// The <see cref="BITMAPINFO.bmiColors"/> member is an array of 16-bit indexes
        /// into the logical palette of the device context specified by <paramref name="hdc"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DIB_RGB_COLORS"/>
        /// </term>
        /// <term>
        /// The <see cref="BITMAPINFO"/> structure contains an array of literal RGB values.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="ppvBits">
        /// A pointer to a variable that receives a pointer to the location of the DIB bit values.
        /// </param>
        /// <param name="hSection">
        /// <para>
        /// A handle to a file-mapping object that the function will use to create the DIB.
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If <paramref name="hSection"/> is not <see cref="NULL"/>,
        /// it must be a handle to a file-mapping object created by calling the <see cref="CreateFileMapping"/> function
        /// with the <see cref="PAGE_READWRITE"/> or <see cref="PAGE_WRITECOPY"/> flag.
        /// Read-only DIB sections are not supported.
        /// Handles created by other means will cause <see cref="CreateDIBSection"/> to fail.
        /// </para>
        /// <para>
        /// If <paramref name="hSection"/> is not <see cref="NULL"/>,
        /// the <see cref="CreateDIBSection"/> function locates the bitmap bit values
        /// at offset <paramref name="offset"/> in the file-mapping object referred to by <paramref name="hSection"/>.
        /// An application can later retrieve the <paramref name="hSection"/> handle
        /// by calling the <see cref="GetObject"/> function with the <see cref="HBITMAP"/> returned by <see cref="CreateDIBSection"/>.
        /// </para>
        /// <para>
        /// If <paramref name="hSection"/> is <see cref="NULL"/>, the system allocates memory for the DIB.
        /// In this case, the <see cref="CreateDIBSection"/> function ignores the <paramref name="offset"/> parameter.
        /// An application cannot later obtain a handle to this memory.
        /// The <see cref="DIBSECTION.dshSection"/> member of the <see cref="DIBSECTION"/> structure
        /// filled in by calling the <see cref="GetObject"/> function will be <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="offset">
        /// The offset from the beginning of the file-mapping object referenced by <paramref name="hSection"/>
        /// where storage for the bitmap bit values is to begin.
        /// This value is ignored if <paramref name="hSection"/> is <see cref="NULL"/>.
        /// The bitmap bit values are aligned on doubleword boundaries,
        /// so <paramref name="offset"/> must be a multiple of the size of a <see cref="DWORD"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the newly created DIB,
        /// and *<paramref name="ppvBits"/> points to the bitmap bit values.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>,
        /// and *<paramref name="ppvBits"/> is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// <see cref="GetLastError"/> can return the following value:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Error code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// As noted above, if <paramref name="hSection"/> is <see cref="NULL"/>,
        /// the system allocates memory for the DIB.
        /// The system closes the handle to that memory
        /// when you later delete the DIB by calling the <see cref="DeleteObject"/> function.
        /// If <paramref name="hSection"/> is not <see cref="NULL"/>,
        /// you must close the <paramref name="hSection"/> memory handle yourself
        /// after calling <see cref="DeleteObject"/> to delete the bitmap.
        /// </para>
        /// <para>
        /// You cannot paste a DIB section from one application into another application.
        /// </para>
        /// <para>
        /// <see cref="CreateDIBSection"/> does not use the <see cref="BITMAPINFOHEADER"/> parameters
        /// <see cref="BITMAPINFOHEADER.biXPelsPerMeter"/> or <see cref="BITMAPINFOHEADER.biYPelsPerMeter"/>
        /// and will not provide resolution information in the <see cref="BITMAPINFO"/> structure.
        /// </para>
        /// <para>
        /// You need to guarantee that the GDI subsystem has completed any drawing to a bitmap
        /// created by <see cref="CreateDIBSection"/> before you draw to the bitmap yourself.
        /// Access to the bitmap must be synchronized.
        /// Do this by calling the <see cref="GdiFlush"/> function.
        /// This applies to any use of the pointer to the bitmap bit values,
        /// including passing the pointer in calls to functions such as <see cref="SetDIBits"/>.
        /// </para>
        /// <para>
        /// ICM: No color management is done.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDIBSection", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateDIBSection([In] HDC hdc, [In] in BITMAPINFO pbmi, [In] DIBColorTableUsages usage,
            [Out] out IntPtr ppvBits, [In] HANDLE hSection, [In] DWORD offset);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDiscardableBitmap"/> function creates a discardable bitmap
        /// that is compatible with the specified device.
        /// The bitmap has the same bits-per-pixel format and the same color palette as the device.
        /// An application can select this bitmap as the current bitmap for a memory device
        /// that is compatible with the specified device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-creatediscardablebitmap"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="cx">
        /// The width, in pixels, of the bitmap.
        /// </param>
        /// <param name="cy">
        /// The height, in pixels, of the bitmap.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the CreateCompatibleBitmap function.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDiscardableBitmap", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateDiscardableBitmap([In] HDC hdc, [In] int cx, [In] int cy);

        /// <summary>
        /// <para>
        /// The <see cref="GetBitmapBits"/> function copies the bitmap bits of a specified device-dependent bitmap into a buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getbitmapbits"/>
        /// </para>
        /// </summary>
        /// <param name="hbit">
        /// A handle to the device-dependent bitmap.
        /// </param>
        /// <param name="cb">
        /// The number of bytes to copy from the bitmap into the buffer.
        /// </param>
        /// <param name="lpvBits">
        /// A pointer to a buffer to receive the bitmap bits.
        /// The bits are stored as an array of byte values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of bytes copied to the buffer.
        /// If the function fails, the return value is zero.
        /// </returns>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the GetDIBits function.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBitmapBits", ExactSpelling = true, SetLastError = true)]
        public static extern LONG GetBitmapBits([In] HBITMAP hbit, [In] LONG cb, [In] LPVOID lpvBits);

        /// <summary>
        /// <para>
        /// The <see cref="GetBitmapDimensionEx"/> function retrieves the dimensions of a compatible bitmap.
        /// The retrieved dimensions must have been set by the <see cref="SetBitmapDimensionEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getbitmapdimensionex"/>
        /// </para>
        /// </summary>
        /// <param name="hbit">
        /// A handle to a compatible bitmap (DDB).
        /// </param>
        /// <param name="lpsize">
        /// A pointer to a <see cref="SIZE"/> structure to receive the bitmap dimensions.
        /// For more information, see Remarks.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The function returns a data structure that contains fields for the height and width of the bitmap, in .01-mm units.
        /// If those dimensions have not yet been set, the structure that is returned will have zeros in those fields.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBitmapDimensionEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetBitmapDimensionEx([In] HBITMAP hbit, [Out] out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetDIBColorTable"/> function retrieves RGB (red, green, blue) color values from a range of entries
        /// in the color table of the DIB section bitmap that is currently selected into a specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdibcolortable"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// A DIB section bitmap must be selected into this device context.
        /// </param>
        /// <param name="iStart">
        /// A zero-based color table index that specifies the first color table entry to retrieve.
        /// </param>
        /// <param name="cEntries">
        /// The number of color table entries to retrieve.
        /// </param>
        /// <param name="prgbq">
        /// A pointer to a buffer that receives an array of <see cref="RGBQUAD"/> data structures
        /// containing color information from the DIB color table.
        /// The buffer must be large enough to contain as many <see cref="RGBQUAD"/> data structures
        /// as the value of <paramref name="cEntries"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of color table entries that the function retrieves.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The GetDIBColorTable function should be called to retrieve the color table for DIB section bitmaps that use 1, 4, or 8 bpp.
        /// The <see cref="BITMAPINFOHEADER.biBitCount"/> member of a bitmap
        /// associated <see cref="BITMAPINFOHEADER"/> structure specifies the number of bits-per-pixel.
        /// DIB section bitmaps with a <see cref="BITMAPINFOHEADER.biBitCount"/> value greater than eight do not have a color table,
        /// but they do have associated color masks.
        /// Call the <see cref="GetObject"/> function to retrieve those color masks.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDIBColorTable", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetDIBColorTable([In] HDC hdc, [In] UINT iStart, [In] UINT cEntries, [Out] RGBQUAD[] prgbq);

        /// <summary>
        /// <para>
        /// The <see cref="GetDIBits"/> function retrieves the bits of the specified compatible bitmap
        /// and copies them into a buffer as a DIB using the specified format.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdibits"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hbm">
        /// A handle to the bitmap.
        /// This must be a compatible bitmap (DDB).
        /// </param>
        /// <param name="start">
        /// The first scan line to retrieve.
        /// </param>
        /// <param name="cLines">
        /// The number of scan lines to retrieve.
        /// </param>
        /// <param name="lpvBits">
        /// A pointer to a buffer to receive the bitmap data.
        /// If this parameter is <see cref="NULL"/>, the function passes the dimensions and format of the bitmap
        /// to the <see cref="BITMAPINFO"/> structure pointed to by the <paramref name="lpbmi"/> parameter.
        /// </param>
        /// <param name="lpbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that specifies the desired format for the DIB data.
        /// </param>
        /// <param name="usage">
        /// <para>
        /// The format of the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure.
        /// It must be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DIB_PAL_COLORS"/>
        /// </term>
        /// <term>
        /// The color table should consist of an array of 16-bit indexes into the current logical palette.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DIB_RGB_COLORS"/>
        /// </term>
        /// <term>
        /// The color table should consist of literal red, green, blue (RGB) values.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the <paramref name="lpvBits"/> parameter is non-<see cref="NULL"/> and the function succeeds,
        /// the return value is the number of scan lines copied from the bitmap.
        /// </para>
        /// <para>
        /// If the <paramref name="lpvBits"/> parameter is <see cref="NULL"/>
        /// and <see cref="GetDIBits"/> successfully fills the <see cref="BITMAPINFO"/> structure,
        /// the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// <para>
        /// This function can return the following value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the requested format for the DIB matches its internal format, the RGB values for the bitmap are copied.
        /// If the requested format doesn't match the internal format, a color table is synthesized.
        /// The following table describes the color table synthesized for each format.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 1_BPP
        /// </term>
        /// <term>
        /// The color table consists of a black and a white entry.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 4_BPP
        /// </term>
        /// <term>
        /// The color table consists of a mix of colors identical to the standard VGA palette.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 8_BPP
        /// </term>
        /// <term>
        /// The color table consists of a general mix of 256 colors defined by GDI.
        /// (Included in these 256 colors are the 20 colors found in the default logical palette.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24_BPP
        /// </term>
        /// <term>
        /// No color table is returned.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the <paramref name="lpvBits"/> parameter is a valid pointer,
        /// the first six members of the <see cref="BITMAPINFOHEADER"/> structure
        /// must be initialized to specify the size and format of the DIB.
        /// The scan lines must be aligned on a <see cref="DWORD"/> except for RLE compressed bitmaps.
        /// </para>
        /// <para>
        /// A bottom-up DIB is specified by setting the height to a positive number,
        /// while a top-down DIB is specified by setting the height to a negative number.
        /// The bitmap color table will be appended to the <see cref="BITMAPINFO"/> structure.
        /// </para>
        /// <para>
        /// If <paramref name="lpvBits"/> is <see cref="NULL"/>,
        /// <see cref="GetDIBits"/> examines the first member of the first structure pointed to by <paramref name="lpbmi"/>.
        /// This member must specify the size, in bytes, of a <see cref="BITMAPCOREHEADER"/> or a <see cref="BITMAPINFOHEADER"/> structure.
        /// The function uses the specified size to determine how the remaining members should be initialized.
        /// </para>
        /// <para>
        /// If <paramref name="lpvBits"/> is <see cref="NULL"/> and the bit count member of <see cref="BITMAPINFO"/> is initialized to zero,
        /// <see cref="GetDIBits"/> fills in a <see cref="BITMAPINFOHEADER"/> structure or <see cref="BITMAPCOREHEADER"/> without the color table.
        /// This technique can be used to query bitmap attributes.
        /// </para>
        /// <para>
        /// The bitmap identified by the <paramref name="hbm"/> parameter
        /// must not be selected into a device context when the application calls this function.
        /// </para>
        /// <para>
        /// The origin for a bottom-up DIB is the lower-left corner of the bitmap;
        /// the origin for a top-down DIB is the upper-left corner.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDIBits", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDIBits([In] HDC hdc, [In] HBITMAP hbm, [In] UINT start, [In] UINT cLines, [In] LPVOID lpvBits,
            [In] in BITMAPINFO lpbmi, [In] UINT usage);

        /// <summary>
        /// <para>
        /// The <see cref="SetBitmapBits"/> function sets the bits of color data for a bitmap to the specified values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setbitmapbits"/>
        /// </para>
        /// </summary>
        /// <param name="hbm">
        /// A handle to the bitmap to be set.
        /// This must be a compatible bitmap (DDB).
        /// </param>
        /// <param name="cb">
        /// The number of bytes pointed to by the <paramref name="pvBits"/> parameter.
        /// </param>
        /// <param name="pvBits">
        /// A pointer to an array of bytes that contain color data for the specified bitmap.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of bytes used in setting the bitmap bits.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The array identified by <paramref name="pvBits"/> must be <see cref="WORD"/> aligned.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the SetDIBits function.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBitmapBits", ExactSpelling = true, SetLastError = true)]
        public static extern LONG SetBitmapBits([In] HBITMAP hbm, [In] DWORD cb, [In] IntPtr pvBits);

        /// <summary>
        /// <para>
        /// The <see cref="SetBitmapDimensionEx"/> function assigns preferred dimensions to a bitmap.
        /// These dimensions can be used by applications; however, they are not used by the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setbitmapdimensionex"/>
        /// </para>
        /// </summary>
        /// <param name="hbm">
        /// A handle to the bitmap. The bitmap cannot be a DIB-section bitmap.
        /// </param>
        /// <param name="w">
        /// The width, in 0.1-millimeter units, of the bitmap.
        /// </param>
        /// <param name="h">
        /// The height, in 0.1-millimeter units, of the bitmap.
        /// </param>
        /// <param name="lpsz">
        /// A pointer to a <see cref="SIZE"/> structure to receive the previous dimensions of the bitmap.
        /// This pointer can be <see cref="NullRef{SIZE}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application can retrieve the dimensions assigned to a bitmap with the <see cref="SetBitmapDimensionEx"/> function
        /// by calling the <see cref="GetBitmapDimensionEx"/> function.
        /// </para>
        /// <para>
        /// The bitmap identified by <paramref name="hbm"/> cannot be a DIB section,
        /// which is a bitmap created by the <see cref="CreateDIBSection"/> function.
        /// If the bitmap is a DIB section, the <see cref="SetBitmapDimensionEx"/> function fails.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBitmapDimensionEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetBitmapDimensionEx([In] HBITMAP hbm, [In] int w, [In] int h, [Out] out SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetDIBColorTable"/> function sets RGB (red, green, blue) color values
        /// in a range of entries in the color table of the DIB that is currently selected into a specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdibcolortable"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A device context. A DIB must be selected into this device context.
        /// </param>
        /// <param name="iStart">
        /// A zero-based color table index that specifies the first color table entry to set.
        /// </param>
        /// <param name="cEntries">
        /// The number of color table entries to set.
        /// </param>
        /// <param name="prgbq">
        /// A pointer to an array of <see cref="RGBQUAD"/> structures containing new color information for the DIB's color table.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of color table entries that the function sets.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function should be called to set the color table for DIBs that use 1, 4, or 8 bpp.
        /// The BitCount member of a bitmap's associated bitmap information header structure.
        /// </para>
        /// <para>
        /// <see cref="BITMAPINFOHEADER"/> structure specifies the number of bits-per-pixel.
        /// Device-independent bitmaps with a <see cref="BITMAPINFOHEADER.biBitCount"/> value greater than 8 do not have a color table.
        /// </para>
        /// <para>
        /// The <see cref="BITMAPV5HEADER.bV5BitCount"/> member of a bitmap's associated <see cref="BITMAPV5HEADER"/> structure
        /// specifies the number of bits-per-pixel.
        /// Device-independent bitmaps with a <see cref="BITMAPV5HEADER.bV5BitCount"/> value greater than 8 do not have a color table.
        /// </para>
        /// <para>
        /// ICM: No color management is performed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDIBColorTable", ExactSpelling = true, SetLastError = true)]
        public static extern UINT SetDIBColorTable([In] HDC hdc, [In] UINT iStart, [In] UINT cEntries, [In] RGBQUAD[] prgbq);

        /// <summary>
        /// <para>
        /// The <see cref="SetDIBits"/> function sets the pixels in a compatible bitmap (DDB)
        /// using the color data found in the specified DIB.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdibits"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="hbm">
        /// A handle to the compatible bitmap (DDB) that is to be altered using the color data from the specified DIB.
        /// </param>
        /// <param name="start">
        /// The starting scan line for the device-independent color data
        /// in the array pointed to by the <paramref name="lpBits"/> parameter.
        /// </param>
        /// <param name="cLines">
        /// The number of scan lines found in the array containing device-independent color data.
        /// </param>
        /// <param name="lpBits">
        /// A pointer to the DIB color data, stored as an array of bytes.
        /// The format of the bitmap values depends on the <see cref="BITMAPINFOHEADER.biBitCount"/> member of the <see cref="BITMAPINFO"/> structure
        /// pointed to by the <paramref name="lpbmi"/> parameter.
        /// </param>
        /// <param name="lpbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that contains information about the DIB.
        /// </param>
        /// <param name="ColorUse">
        /// <para>
        /// Indicates whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure was provided and,
        /// if so, whether <see cref="BITMAPINFO.bmiColors"/> contains explicit red, green, blue (RGB) values or palette indexes.
        /// The <paramref name="ColorUse"/> parameter must be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DIB_PAL_COLORS"/>
        /// </term>
        /// <term>
        /// The color table consists of an array of 16-bit indexes into the logical palette
        /// of the device context identified by the <paramref name="hdc"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DIB_RGB_COLORS"/>
        /// </term>
        /// <term>
        /// The color table is provided and contains literal RGB values.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of scan lines copied.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// <para>
        /// This can be the following value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Optimal bitmap drawing speed is obtained when the bitmap bits are indexes into the system palette.
        /// </para>
        /// <para>
        /// Applications can retrieve the system palette colors and indexes by calling the <see cref="GetSystemPaletteEntries"/> function.
        /// After the colors and indexes are retrieved, the application can create the DIB.
        /// For more information, see System Palette.
        /// </para>
        /// <para>
        /// The device context identified by the <paramref name="hdc"/> parameter is used
        /// only if the <see cref="DIB_PAL_COLORS"/> constant is set for the <paramref name="ColorUse"/> parameter; otherwise it is ignored.
        /// </para>
        /// <para>
        /// The bitmap identified by the <paramref name="hbm"/> parameter must not be selected into a device context
        /// when the application calls this function.
        /// </para>
        /// <para>
        /// The scan lines must be aligned on a <see cref="DWORD"/> except for RLE-compressed bitmaps.
        /// </para>
        /// <para>
        /// The origin for bottom-up DIBs is the lower-left corner of the bitmap;
        /// the origin for top-down DIBs is the upper-left corner of the bitmap.
        /// </para>
        /// <para>
        /// ICM: Color management is performed if color management has been enabled
        /// with a call to <see cref="SetICMMode"/> with the iEnableICM parameter set to <see cref="ICM_ON"/>.
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/>
        /// that specifies the gamma and endpoints members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the gamma and endpoints members
        /// or the profileData and profileSize members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDIBits", ExactSpelling = true, SetLastError = true)]
        public static extern int SetDIBits([In] HDC hdc, [In] HBITMAP hbm, [In] UINT start, [In] UINT cLines, [In] IntPtr lpBits,
            [In] in BITMAPINFO lpbmi, [In] UINT ColorUse);
    }
}
