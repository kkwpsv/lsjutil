﻿namespace Lsj.Util.Net.Web.Interfaces
{
    /// <summary>
    /// HttpContext
    /// </summary>
    internal interface IContext
    {
        ContextStatus Status
        {
            get;
        }

        void Dispose();
        void Start();
    }
}
