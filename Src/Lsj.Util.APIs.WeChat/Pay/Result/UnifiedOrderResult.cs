namespace Lsj.Util.APIs.WeChat.Pay.Result
{
    /// <summary>
    /// Unified Order Result
    /// </summary>
    public class UnifiedOrderResult : BaseResult
    {
        /// <summary>
        /// Unified Order Result
        /// </summary>
        /// <param name="key"></param>
        public UnifiedOrderResult(string key) : base(key)
        {
        }

        /// <summary>
        /// Prepay ID
        /// </summary>
        public string PrepayID { get; private set; }

        /// <summary>
        /// Code Url
        /// </summary>
        public string CodeUrl { get; private set; }

        /// <summary>
        /// MWeb Url
        /// </summary>
        public string MWebUrl { get; private set; }

        /// <summary>
        /// Parse Extra
        /// </summary>
        protected override void ParseExtra()
        {
            PrepayID = _data["prepay_id"];
            CodeUrl = _data["code_url"];
            MWebUrl = _data["mweb_url"];
        }
    }
}
