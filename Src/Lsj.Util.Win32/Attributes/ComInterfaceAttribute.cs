using System;

namespace Lsj.Util.Win32.Attributes
{
    /// <summary>
    /// Com Interface
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    public class ComInterfaceAttribute : Attribute
    {
        /// <summary>
        /// The IID of this interface
        /// </summary>
        public string? IID { get; set; }

        /// <summary>
        /// Begin VTable slot index
        /// </summary>
        public int BeginVTableSlotIndex { get; set; }

        /// <summary>
        /// End VTable slot index
        /// </summary>
        public int EndVTableSlotIndex { get; set; }

        /// <summary>
        /// The types that this interface inherited from
        /// </summary>
        public Type[] InheritedFromTypes { get; set; } = [];
    }
}
