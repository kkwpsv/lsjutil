using System;

namespace Lsj.Util.APIs.Alipay.Pay.Result
{
    /// <summary>
    /// Base Result
    /// </summary>
    public abstract class BaseResult
    {
        /// <summary>
        /// Alipay Pay Data
        /// </summary>
        protected AlipayPayData data;

        /// <summary>
        /// Status
        /// </summary>
        public virtual bool Status => ParseStatus && SignStatus;

        /// <summary>
        /// Error String
        /// </summary>
        public string ErrorString { get; protected set; }

        /// <summary>
        /// Parse Status
        /// </summary>
        public bool ParseStatus { get; protected set; } = true;

        /// <summary>
        /// Sign Status
        /// </summary>
        public bool SignStatus { get; protected set; } = false;

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        public virtual void Parse(string str) => throw new NotImplementedException();

        /// <summary>
        /// Check Sign
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckSign() => data.CheckSignV1();

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected virtual void ParseExtra()
        {

        }

    }
}
