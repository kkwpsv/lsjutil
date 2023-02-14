using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Represents the different process mitigation policies.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-process_mitigation_policy"/>
    /// </para>
    /// </summary>
    public enum PROCESS_MITIGATION_POLICY
    {
        /// <summary>
        /// The data execution prevention (DEP) policy of the process.
        /// </summary>
        ProcessDEPPolicy,

        /// <summary>
        /// The Address Space Layout Randomization (ASLR) policy of the process.
        /// </summary>
        ProcessASLRPolicy,

        /// <summary>
        /// The policy that turns off the ability of the process to generate dynamic code or modify existing executable code.
        /// </summary>
        ProcessDynamicCodePolicy,

        /// <summary>
        /// The process will receive a fatal error if it manipulates an invalid handle.
        /// Useful for preventing downstream problems in a process due to handle misuse.
        /// </summary>
        ProcessStrictHandleCheckPolicy,

        /// <summary>
        /// Disables the ability to use NTUser/GDI functions at the lowest layer.
        /// </summary>
        ProcessSystemCallDisablePolicy,

        /// <summary>
        /// Returns the mask of valid bits for all the mitigation options on the system.
        /// An application can set many mitigation options without querying the operating system for mitigation options
        /// by combining bitwise with the mask to exclude all non-supported bits at once.
        /// </summary>
        ProcessMitigationOptionsMask,

        /// <summary>
        /// The policy that prevents some built-in third party extension points from being turned on,
        /// which prevents legacy extension point DLLs from being loaded into the process.
        /// </summary>
        ProcessExtensionPointDisablePolicy,

        /// <summary>
        /// The Control Flow Guard (CFG) policy of the process.
        /// </summary>
        ProcessControlFlowGuardPolicy,

        /// <summary>
        /// The policy of a process that can restrict image loading to those images that are either signed by Microsoft,
        /// by the Windows Store, or by Microsoft, the Windows Store and the Windows Hardware Quality Labs (WHQL).
        /// </summary>
        ProcessSignaturePolicy,

        /// <summary>
        /// The policy that turns off the ability of the process to load non-system fonts.
        /// </summary>
        ProcessFontDisablePolicy,

        /// <summary>
        /// The policy that turns off the ability of the process to load images from some locations,
        /// such a remote devices or files that have the low mandatory label.
        /// </summary>
        ProcessImageLoadPolicy,

        /// <summary>
        /// 
        /// </summary>
        ProcessSystemCallFilterPolicy,

        /// <summary>
        /// 
        /// </summary>
        ProcessPayloadRestrictionPolicy,

        /// <summary>
        /// 
        /// </summary>
        ProcessChildProcessPolicy,

        /// <summary>
        /// 
        /// </summary>
        ProcessSideChannelIsolationPolicy,

        /// <summary>
        /// Windows 10, version 2004 and above: The policy regarding user-mode Hardware-enforced Stack Protection for the process.
        /// </summary>
        ProcessUserShadowStackPolicy,

        /// <summary>
        /// 
        /// </summary>
        ProcessRedirectionTrustPolicy,

        /// <summary>
        /// 
        /// </summary>
        MaxProcessMitigationPolicy
    }
}
