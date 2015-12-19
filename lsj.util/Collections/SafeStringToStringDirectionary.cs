namespace Lsj.Util.Collections
{
    /// <summary>
    /// SafeStringToStringDirectionary
    /// </summary>
    public class SafeStringToStringDirectionary : SafeDictionary<string,string>
    {
        /// <summary>
        /// NullValue
        /// </summary>
        public sealed override string NullValue
        {
            get
            {
                return string.Empty;
            }
        }
    }
}
