using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Edge Flags
    /// </summary>
    public enum BorderStyles : uint
    {
        /// <summary>
        /// BDR_RAISEDOUTER
        /// </summary>
        BDR_RAISEDOUTER = 0x0001,

        /// <summary>
        /// BDR_SUNKENOUTER
        /// </summary>
        BDR_SUNKENOUTER = 0x0002,

        /// <summary>
        /// BDR_RAISEDINNER
        /// </summary>
        BDR_RAISEDINNER = 0x0004,

        /// <summary>
        /// BDR_SUNKENINNER
        /// </summary>
        BDR_SUNKENINNER = 0x0008,

        /// <summary>
        /// BDR_OUTER
        /// </summary>
        BDR_OUTER = BDR_RAISEDOUTER | BDR_SUNKENOUTER,

        /// <summary>
        /// BDR_INNER
        /// </summary>
        BDR_INNER = BDR_RAISEDINNER | BDR_SUNKENINNER,

        /// <summary>
        /// BDR_RAISED
        /// </summary>
        BDR_RAISED = BDR_RAISEDOUTER | BDR_RAISEDINNER,

        /// <summary>
        /// BDR_SUNKEN
        /// </summary>
        BDR_SUNKEN = BDR_SUNKENOUTER | BDR_SUNKENINNER,

        /// <summary>
        /// EDGE_RAISED
        /// </summary>
        EDGE_RAISED = BDR_RAISEDOUTER | BDR_RAISEDINNER,

        /// <summary>
        /// EDGE_SUNKEN
        /// </summary>
        EDGE_SUNKEN = BDR_SUNKENOUTER | BDR_SUNKENINNER,

        /// <summary>
        /// EDGE_ETCHED
        /// </summary>
        EDGE_ETCHED = BDR_SUNKENOUTER | BDR_RAISEDINNER,

        /// <summary>
        /// EDGE_BUMP
        /// </summary>
        EDGE_BUMP = BDR_RAISEDOUTER | BDR_SUNKENINNER,
    }
}
