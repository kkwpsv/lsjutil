﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="SECURITY_IMPERSONATION_LEVEL"/> enumeration contains values that specify security impersonation levels.
    /// Security impersonation levels govern the degree to which a server process can act on behalf of a client process.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ne-winnt-security_impersonation_level"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Impersonation is the ability of a process to take on the security attributes of another process.
    /// </remarks>
    public enum SECURITY_IMPERSONATION_LEVEL
    {
        /// <summary>
        /// The server process cannot obtain identification information about the client, and it cannot impersonate the client.
        /// It is defined with no value given, and thus, by ANSI C rules, defaults to a value of zero.
        /// </summary>
        SecurityAnonymous,

        /// <summary>
        /// The server process can obtain information about the client, such as security identifiers and privileges,
        /// but it cannot impersonate the client.
        /// This is useful for servers that export their own objects, for example, database products that export tables and views.
        /// Using the retrieved client-security information, the server can make access-validation decisions without
        /// being able to use other services that are using the client's security context.
        /// </summary>
        SecurityIdentification,

        /// <summary>
        /// The server process can impersonate the client's security context on its local system.
        /// The server cannot impersonate the client on remote systems.
        /// </summary>
        SecurityImpersonation,

        /// <summary>
        /// The server process can impersonate the client's security context on remote systems.
        /// </summary>
        SecurityDelegation
    }
}
