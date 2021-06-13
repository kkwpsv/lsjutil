namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Primary Orders
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winddi/ns-winddi-gdiinfo"/>
    /// </para>
    /// </summary>
    public enum PrimaryOrders : uint
    {
        /// <summary>
        /// Device output order is RGB or CMY. Red or cyan is in the least significant bits; blue or yellow is in the most significant bits.
        /// </summary>
        PRIMARY_ORDER_ABC = 0,

        /// <summary>
        /// Device output order is RBG or CYM. Red or cyan is in the least significant bits; green or magenta is in the most significant bits.
        /// </summary>
        PRIMARY_ORDER_ACB = 1,

        /// <summary>
        /// Device output order is GRB or MCY. Green or magenta is in the least significant bits; blue or yellow is in the most significant bits.
        /// </summary>
        PRIMARY_ORDER_BAC = 2,

        /// <summary>
        /// Device output order is GBR or MYC. Green or magenta is in the least significant bits; red or cyan is in the most significant bits.
        /// </summary>
        PRIMARY_ORDER_BCA = 3,

        /// <summary>
        /// Device output order is BGR or YMC. Blue or yellow is in the least significant bits; red or cyan is in the most significant bits.
        /// </summary>
        PRIMARY_ORDER_CBA = 4,

        /// <summary>
        /// Device output order is BRG or YCM. Blue or yellow is in the least significant bits; green or magenta is in the most significant bits.
        /// </summary>
        PRIMARY_ORDER_CAB = 5,
    }
}
