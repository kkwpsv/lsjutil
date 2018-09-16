using System.Collections.Generic;


namespace Lsj.Util.Collections

{
    /// <summary>
    /// Safe string to string directionary
    /// </summary>
    public class SafeStringToStringDictionary : SafeDictionary<string, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.SafeStringToStringDictionary"/> class.
        /// </summary>
        public SafeStringToStringDictionary() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Collections.SafeStringToStringDirectionary"/> class.
        /// </summary>
        /// <param name="src">Source</param>
        public SafeStringToStringDictionary(Dictionary<string, string> src) : base(src)
        {
        }

        /// <summary>
        /// NullValue
        /// </summary>
        public sealed override string NullValue => string.Empty;
    }
}
