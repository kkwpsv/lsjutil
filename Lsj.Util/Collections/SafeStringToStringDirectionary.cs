using System.Collections.Generic;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Collections
#else
namespace Lsj.Util.Collections
#endif
{
    /// <summary>
    /// Safe string to string directionary.
    /// </summary>
    public class SafeStringToStringDirectionary : SafeDictionary<string, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.SafeStringToStringDirectionary"/> class.
        /// </summary>
        public SafeStringToStringDirectionary() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.SafeStringToStringDirectionary"/> class.
        /// </summary>
        /// <param name="src">Source.</param>
        public SafeStringToStringDirectionary(Dictionary<string, string> src) : base(src)
        {
        }

        /// <summary>
        /// Gets the null value.
        /// </summary>
        /// <value>The null value.</value>
        public sealed override string NullValue => string.Empty;
    }
}
