using System;
using System.Security.Cryptography;

namespace Lsj.Util
{
    public class TrueRandom : DisposableClass, IDisposable
    {
        private readonly RNGCryptoServiceProvider csp;

        public TrueRandom()
        {
            this.csp = new RNGCryptoServiceProvider();
        }

        protected override void CleanUpManagedResources()
        {
            this.csp.Dispose();
            base.CleanUpManagedResources();
        }

        public int NextInt()
        {
            var result = new byte[4];
            this.csp.GetBytes(result);
            return QuickBitConverter.ConvertToInt(result);
        }
    }
}
