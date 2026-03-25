using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies whether Direct2D provides synchronization for an <see cref="ID2D1Factory"/> and the resources it creates,
    /// so that they may be safely accessed from multiple threads.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_factory_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When you create a factory, you can specify whether it is multithreaded or singlethreaded.
    /// A singlethreaded factory provides no serialization against any other single threaded instance within Direct2D,
    /// so this mechanism provides a very large degree of scaling on the CPU.
    /// </para>
    /// <para>
    /// You can also create a multithreaded factory instance.
    /// In this case, the factory and all derived objects can be used from any thread,
    /// and each render target can be rendered to independently.
    /// Direct2D serializes calls to these objects,
    /// so a single multithreaded Direct2D instance won't scale as well on the CPU as many single threaded instances.
    /// However, the resources can be shared within the multithreaded instance.
    /// </para>
    /// <para>
    /// Note the qualifier "On the CPU": GPUs generally take advantage of fine-grained parallelism more so than CPUs.
    /// For example, multithreaded calls from the CPU might still end up being serialized when being sent to the GPU;
    /// however, a whole bank of pixel and vertex shaders will run in parallel to perform the rendering.
    /// </para>
    /// </remarks>
    public enum D2D1_FACTORY_TYPE : uint
    {
        /// <summary>
        /// No synchronization is provided for accessing or writing to the factory or the objects it creates.
        /// If the factory or the objects are called from multiple threads,
        /// it is up to the application to provide access locking.
        /// </summary>
        D2D1_FACTORY_TYPE_SINGLE_THREADED = 0,

        /// <summary>
        /// Direct2D provides synchronization for accessing and writing to the factory and the objects it creates,
        /// enabling safe access from multiple threads.
        /// </summary>
        D2D1_FACTORY_TYPE_MULTI_THREADED = 1,

        /// <summary>
        /// 
        /// </summary>
        D2D1_FACTORY_TYPE_FORCE_DWORD = 0xffffffff,
    }
}
