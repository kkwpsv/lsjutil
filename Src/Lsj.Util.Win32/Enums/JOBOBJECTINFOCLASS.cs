using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// JOBOBJECTINFOCLASS
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/jobapi2/nf-jobapi2-setinformationjobobject"/>
    /// </para>
    /// </summary>
    public enum JOBOBJECTINFOCLASS
    {
        /// <summary>
        /// JobObjectBasicAccountingInformation
        /// </summary>
        JobObjectBasicAccountingInformation = 1,

        /// <summary>
        /// JobObjectBasicLimitInformation
        /// </summary>
        JobObjectBasicLimitInformation,

        /// <summary>
        /// JobObjectBasicProcessIdList
        /// </summary>
        JobObjectBasicProcessIdList,

        /// <summary>
        /// JobObjectBasicUIRestrictions
        /// </summary>
        JobObjectBasicUIRestrictions,

        /// <summary>
        /// JobObjectSecurityLimitInformation
        /// </summary>
        [Obsolete]
        JobObjectSecurityLimitInformation,

        /// <summary>
        ///JobObjectEndOfJobTimeInformation
        /// </summary>
        JobObjectEndOfJobTimeInformation,

        /// <summary>
        /// JobObjectAssociateCompletionPortInformation
        /// </summary>
        JobObjectAssociateCompletionPortInformation,

        /// <summary>
        /// JobObjectBasicAndIoAccountingInformation
        /// </summary>
        JobObjectBasicAndIoAccountingInformation,

        /// <summary>
        /// JobObjectExtendedLimitInformation
        /// </summary>
        JobObjectExtendedLimitInformation,

        /// <summary>
        /// JobObjectJobSetInformation
        /// </summary>
        JobObjectJobSetInformation,

        /// <summary>
        /// JobObjectGroupInformation
        /// </summary>
        JobObjectGroupInformation,

        /// <summary>
        /// JobObjectNotificationLimitInformation
        /// </summary>
        JobObjectNotificationLimitInformation,

        /// <summary>
        /// JobObjectLimitViolationInformation
        /// </summary>
        JobObjectLimitViolationInformation,

        /// <summary>
        /// JobObjectGroupInformationEx
        /// </summary>
        JobObjectGroupInformationEx,

        /// <summary>
        /// JobObjectCpuRateControlInformation
        /// </summary>
        JobObjectCpuRateControlInformation,

        /// <summary>
        /// JobObjectCompletionFilter
        /// </summary>
        JobObjectCompletionFilter,

        /// <summary>
        /// JobObjectCompletionCounter
        /// </summary>
        JobObjectCompletionCounter,

        /// <summary>
        /// JobObjectReserved1Information
        /// </summary>
        JobObjectReserved1Information = 18,

        /// <summary>
        /// JobObjectReserved2Information
        /// </summary>
        JobObjectReserved2Information,

        /// <summary>
        /// JobObjectReserved3Information
        /// </summary>
        JobObjectReserved3Information,

        /// <summary>
        /// JobObjectReserved4Information
        /// </summary>
        JobObjectReserved4Information,

        /// <summary>
        /// JobObjectReserved5Information
        /// </summary>
        JobObjectReserved5Information,

        /// <summary>
        /// JobObjectReserved6Information
        /// </summary>
        JobObjectReserved6Information,

        /// <summary>
        /// JobObjectReserved7Information
        /// </summary>
        JobObjectReserved7Information,

        /// <summary>
        /// JobObjectReserved8Information
        /// </summary>
        JobObjectReserved8Information,

        /// <summary>
        /// JobObjectReserved9Information
        /// </summary>
        JobObjectReserved9Information,

        /// <summary>
        /// JobObjectReserved10Information
        /// </summary>
        JobObjectReserved10Information,

        /// <summary>
        /// JobObjectReserved11Information
        /// </summary>
        JobObjectReserved11Information,

        /// <summary>
        /// JobObjectReserved12Information
        /// </summary>
        JobObjectReserved12Information,

        /// <summary>
        /// JobObjectReserved13Information
        /// </summary>
        JobObjectReserved13Information,

        /// <summary>
        /// JobObjectReserved14Information
        /// </summary>
        JobObjectReserved14Information = 31,

        /// <summary>
        /// JobObjectNetRateControlInformation
        /// </summary>
        JobObjectNetRateControlInformation,

        /// <summary>
        /// JobObjectNotificationLimitInformation2
        /// </summary>
        JobObjectNotificationLimitInformation2,

        /// <summary>
        /// JobObjectLimitViolationInformation2
        /// </summary>
        JobObjectLimitViolationInformation2,

        /// <summary>
        /// JobObjectCreateSilo
        /// </summary>
        JobObjectCreateSilo,

        /// <summary>
        /// JobObjectSiloBasicInformation
        /// </summary>
        JobObjectSiloBasicInformation,

        /// <summary>
        /// JobObjectReserved15Information
        /// </summary>
        JobObjectReserved15Information = 37,

        /// <summary>
        /// JobObjectReserved16Information
        /// </summary>
        JobObjectReserved16Information = 38,

        /// <summary>
        /// JobObjectReserved17Information
        /// </summary>
        JobObjectReserved17Information = 39,

        /// <summary>
        /// JobObjectReserved18Information
        /// </summary>
        JobObjectReserved18Information = 40,

        /// <summary>
        /// JobObjectReserved19Information
        /// </summary>
        JobObjectReserved19Information = 41,

        /// <summary>
        /// JobObjectReserved20Information
        /// </summary>
        JobObjectReserved20Information = 42,

        /// <summary>
        /// JobObjectReserved21Information
        /// </summary>
        JobObjectReserved21Information = 43,

        /// <summary>
        /// JobObjectReserved22Information
        /// </summary>
        JobObjectReserved22Information = 44,

        /// <summary>
        /// JobObjectReserved23Information
        /// </summary>
        JobObjectReserved23Information = 45,

        /// <summary>
        /// JobObjectReserved24Information
        /// </summary>
        JobObjectReserved24Information = 46,

        /// <summary>
        /// JobObjectReserved25Information
        /// </summary>
        JobObjectReserved25Information = 47,

        /// <summary>
        /// MaxJobObjectInfoClass
        /// </summary>
        MaxJobObjectInfoClass
    }
}
