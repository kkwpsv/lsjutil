using System;
using System.Security.Cryptography;

namespace Lsj.Util
{
    /// <summary>
    /// True Random
    /// </summary>
    public class TrueRandom : DisposableClass
    {
        private readonly RNGCryptoServiceProvider csp;

        /// <summary>
        /// Initialize
        /// </summary>
        public TrueRandom()
        {
            this.csp = new RNGCryptoServiceProvider();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            this.csp.Dispose();
            base.CleanUpManagedResources();
        }

        /// <summary>
        /// Get Next Int Value
        /// </summary>
        /// <returns></returns>
        public int NextInt()
        {
            var result = new byte[4];
            this.csp.GetBytes(result);
            return QuickBitConverter.ConvertToInt(result);
        }
    }
}
