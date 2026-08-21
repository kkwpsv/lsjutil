using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes information about present that helps the operating system optimize presentation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_present_parameters"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by the <see cref="IDXGISwapChain1.Present1"/> method.
    /// </para>
    /// <para>
    /// The scroll rectangle and the list of dirty rectangles could overlap.
    /// In this situation, the dirty rectangles take priority.
    /// Applications can then have pieces of dynamic content on top of a scrolled area.
    /// For example, an application could scroll a page and play video at the same time.
    /// </para>
    /// <para>
    /// The following diagram and coordinates illustrate this example.syntax
    /// </para>
    /// 
    /// <para>
    /// Parts of the previous frame and content that the application renders are combined
    /// to produce the final frame that the operating system presents on the display screen.
    /// Most of the window is scrolled from the previous frame.
    /// The application must update the video frame with the new chunk of content that appears due to scrolling.
    /// </para>
    /// <para>
    /// The dashed rectangle shows the scroll rectangle in the current frame.
    /// The scroll rectangle is specified by the pScrollRect member.
    /// The arrow shows the scroll offset.
    /// The scroll offset is specified by the <see cref="pScrollOffset"/> member.
    /// Filled rectangles show dirty rectangles that the application updated with new content.
    /// The filled rectangles are specified by the <see cref="DirtyRectsCount"/> and <see cref="pDirtyRects"/> members.
    /// </para>
    /// <para>
    /// The scroll rectangle and offset are not supported for the <see cref="DXGI_SWAP_EFFECT_DISCARD"/>
    /// or <see cref="DXGI_SWAP_EFFECT_SEQUENTIAL"/> present option.
    /// Dirty rectangles and scroll rectangle are not supported for multisampled swap chains.
    /// </para>
    /// <para>
    /// The actual implementation of composition and necessary bitblts is different for the bitblt model and the flip model.
    /// For more info about these models, see DXGI Flip Model.
    /// </para>
    /// <para>
    /// For more info about the flip-model swap chain and optimizing presentation,
    /// see Enhancing presentation with the flip model, dirty rectangles, and scrolled areas.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_PRESENT_PARAMETERS
    {
        /// <summary>
        /// The number of updated rectangles that you update in the back buffer for the presented frame.
        /// The operating system uses this information to optimize presentation.
        /// You can set this member to 0 to indicate that you update the whole frame.
        /// </summary>
        public UINT DirtyRectsCount;

        /// <summary>
        /// A list of updated rectangles that you update in the back buffer for the presented frame.
        /// An application must update every single pixel in each rectangle that it reports to the runtime;
        /// the application cannot assume that the pixels are saved from the previous frame.
        /// For more information about updating dirty rectangles, see Remarks.
        /// You can set this member to <see cref="NULL"/> if <see cref="DirtyRectsCount"/> is 0.
        /// An application must not update any pixel outside of the dirty rectangles.
        /// </summary>
        public nint pDirtyRects;

        /// <summary>
        /// <para>
        /// A pointer to the scrolled rectangle.
        /// The scrolled rectangle is the rectangle of the previous frame
        /// from which the runtime bit-block transfers (bitblts) content.
        /// The runtime also uses the scrolled rectangle to optimize presentation
        /// in terminal server and indirect display scenarios.
        /// </para>
        /// <para>
        /// The scrolled rectangle also describes the destination rectangle,
        /// that is, the region on the current frame that is filled with scrolled content.
        /// You can set this member to <see cref="NULL"/> to indicate that no content is scrolled from the previous frame.
        /// </para>
        /// </summary>
        public nint pScrollRect;

        /// <summary>
        /// A pointer to the offset of the scrolled area that goes from the source rectangle
        /// (of previous frame) to the destination rectangle (of current frame).
        /// You can set this member to <see cref="NULL"/> to indicate no offset.
        /// </summary>
        public nint pScrollOffset;
    }
}
