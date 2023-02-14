using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.Enums.DVASPECT;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies new drawing aspects used to optimize the drawing process.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-dvaspect2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To support drawing optimizations to reduce flicker, an object needs to be able to draw and return information about three separate aspects of itself.
    /// <see cref="DVASPECT_CONTENT"/>: Specifies the entire content of an object. All objects should support this aspect.
    /// <see cref="DVASPECT_OPAQUE"/>: Represents the opaque, easy to clip parts of an object. Objects may or may not support this aspect.
    /// <see cref="DVASPECT_TRANSPARENT"/>:
    /// Represents the transparent or irregular parts of on object, typically parts that are expensive or impossible to clip out.
    /// Objects may or may not support this aspect.
    /// The container can determine which of these drawing aspects an object supports by calling the new method <see cref="IViewObjectEx.GetViewStatus"/>.
    /// Individual bits return information about which aspects are supported.
    /// If an object does not support the <see cref="IViewObjectExinterface"/>, it is assumed to support only <see cref="DVASPECT_CONTENT"/>.
    /// Depending on which aspects are supported, the container can ask the object to draw itself during the front to back pass only,
    /// the back to front pass only, or both. The various possible cases are:
    /// Objects supporting only <see cref="DVASPECT_CONTENT"/> should be drawn during the back to front pass,
    /// with all opaque parts of any overlapping object clipped out.
    /// Since all objects should support this aspect, a container not concerned about flickering - maybe because it is drawing in an offscreen bitmap
    /// - can opt to draw all objects that way and skip the front to back pass.
    /// Objects supporting <see cref="DVASPECT_OPAQUE"/> may be asked to draw this aspect during the front to back pass.
    /// The container is responsible for clipping out the object's opaque regions before painting any further object behind it.
    /// Objects supporting <see cref="DVASPECT_TRANSPARENT"/> may be asked to draw this aspect during the back to front pass.
    /// The container is responsible for clipping out opaque parts of overlapping objects before letting an object draw this aspect.
    /// Even when <see cref="DVASPECT_OPAQUE"/> and <see cref="DVASPECT_TRANSPARENT"/> are supported, the container is free to use these aspects or not.
    /// In particular, if it is painting in an offscreen bitmap and consequently is unconcerned about flicker,
    /// the container may use <see cref="DVASPECT_CONTENT"/> and a one-pass drawing only.
    /// However, in a two-pass drawing, if the container uses <see cref="DVASPECT_OPAQUE"/> during the front to back pass,
    /// then it must use <see cref="DVASPECT_TRANSPARENT"/> during the back to front pass to complete the rendering of the object.
    /// </remarks>
    public enum DVASPECT2
    {
        /// <summary>
        /// Represents the opaque, easy to clip parts of an object. Objects may or may not support this aspect.
        /// </summary>
        DVASPECT_OPAQUE = 16,

        /// <summary>
        /// Represents the transparent or irregular parts of on object, typically parts that are expensive or impossible to clip out.
        /// Objects may or may not support this aspect.
        /// </summary>
        DVASPECT_TRANSPARENT = 32,
    }
}
