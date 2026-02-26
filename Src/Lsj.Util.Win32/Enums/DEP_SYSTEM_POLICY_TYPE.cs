using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// DEP_SYSTEM_POLICY_TYPE
    /// </summary>
    public enum DEP_SYSTEM_POLICY_TYPE
    {
        /// <summary>
        /// DEPPolicyAlwaysOff
        /// </summary>
        DEPPolicyAlwaysOff = 0,

        /// <summary>
        /// DEPPolicyAlwaysOn
        /// </summary>
        DEPPolicyAlwaysOn,

        /// <summary>
        /// DEPPolicyOptIn
        /// </summary>
        DEPPolicyOptIn,

        /// <summary>
        /// DEPPolicyOptOut
        /// </summary>
        DEPPolicyOptOut,

        /// <summary>
        /// DEPTotalPolicyCount
        /// </summary>
        DEPTotalPolicyCount
    }
}
