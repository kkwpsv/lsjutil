namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSON Parser Settings
    /// </summary>
    public class JSONParserSettings
    {
        /// <summary>
        /// Is Debug
        /// </summary>
        public bool IsDebug
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Ignore Not Exists Properties
        /// </summary>
        public bool IgnoreNotExistsProperties
        {
            get;
            set;
        } = true;

        /// <summary>
        /// Ignore Not Writable Properties
        /// </summary>
        public bool IgnoreNotWritableProperties
        {
            get;
            set;
        } = true;

        /// <summary>
        /// Max Recursion Layer
        /// </summary>
        public int MaxLayer
        {
            get;
            set;
        } = 100;

        /// <summary>
        /// Allow Partial JSON
        /// </summary>
        public bool AllowPartial
        {
            get;
            set;
        }
    }
}
