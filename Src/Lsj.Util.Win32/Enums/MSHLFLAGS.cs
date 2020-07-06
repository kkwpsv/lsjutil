using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies why the marshaling is to be done.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wtypesbase/ne-wtypesbase-mshlflags
    /// </para>
    /// </summary>
    public enum MSHLFLAGS : uint
    {
        /// <summary>
        /// The marshaling is occurring because an interface pointer is being passed from one process to another.
        /// This is the normal case. The data packet produced by the marshaling process will be unmarshaled in the destination process.
        /// The marshaled data packet can be unmarshaled just once, or not at all. If the receiver unmarshals the data packet successfully,
        /// the <see cref="CoReleaseMarshalData"/> function is automatically called on the data packet as part of the unmarshaling process.
        /// If the receiver does not or cannot unmarshal the data packet, the sender must call <see cref="CoReleaseMarshalData"/> on the data packet.
        /// </summary>
        MSHLFLAGS_NORMAL = 0,

        /// <summary>
        /// The marshaling is occurring because the data packet is to be stored in a globally accessible table
        /// from which it can be unmarshaled one or more times, or not at all.
        /// The presence of the data packet in the table counts as a strong reference to the interface being marshaled,
        /// meaning that it is sufficient to keep the object alive.
        /// When the data packet is removed from the table, the table implementer
        /// must call the <see cref="CoReleaseMarshalData"/> function on the data packet.
        /// <see cref="MSHLFLAGS_TABLESTRONG"/> is used by the <see cref="RegisterDragDrop"/> function when registering a window as a drop target.
        /// This keeps the window registered as a drop target no matter how many times the end user drags across the window.
        /// The <see cref="RevokeDragDrop"/> function calls <see cref="CoReleaseMarshalData"/>.
        /// </summary>
        MSHLFLAGS_TABLESTRONG = 1,

        /// <summary>
        /// The marshaling is occurring because the data packet is to be stored in a globally accessible table
        /// from which it can be unmarshaled one or more times, or not at all.
        /// However, the presence of the data packet in the table acts as a weak reference to the interface being marshaled,
        /// meaning that it is not sufficient to keep the object alive.
        /// When the data packet is removed from the table, the table implementer
        /// must call the <see cref="CoReleaseMarshalData"/> function on the data packet.
        /// <see cref="MSHLFLAGS_TABLEWEAK"/> is typically used when registering an object in the running object table (ROT).
        /// This prevents the object's entry in the ROT from keeping the object alive in the absence of any other connections.
        /// See <see cref="IRunningObjectTable.Register"/> for more information.
        /// </summary>
        MSHLFLAGS_TABLEWEAK = 2,

        /// <summary>
        /// Adding this flag to an original object marshaling (as opposed to marshaling a proxy) will disable the ping protocol for that object.
        /// </summary>
        MSHLFLAGS_NOPING = 4,

        /// <summary>
        /// 
        /// </summary>
        MSHLFLAGS_RESERVED1 = 8,

        /// <summary>
        /// 
        /// </summary>
        MSHLFLAGS_RESERVED2 = 16,

        /// <summary>
        /// 
        /// </summary>
        MSHLFLAGS_RESERVED3 = 32,

        /// <summary>
        /// 
        /// </summary>
        MSHLFLAGS_RESERVED4 = 64
    }
}
