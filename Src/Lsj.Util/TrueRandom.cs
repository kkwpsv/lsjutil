using System;
using System.Security.Cryptography;

namespace Lsj.Util
{
    /// <summary>
    /// True Random
    /// </summary>
    public class TrueRandom : DisposableClass
    {
        private readonly RandomNumberGenerator _rng;

        /// <summary>
        /// Initialize
        /// </summary>
        public TrueRandom()
        {

            _rng = RandomNumberGenerator.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            _rng.Dispose();
            base.CleanUpManagedResources();
        }

        /// <summary>
        /// Get Next Int Value
        /// </summary>
        /// <returns></returns>
        public int NextInt()
        {
            var result = new byte[4];
            _rng.GetBytes(result);
            return QuickBitConverter.ConvertToInt(result);
        }
    }
}
