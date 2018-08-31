namespace Lsj.Util.APIs.WeChat.Pay.Result
{
    public class UnifiedOrderResult : BaseResult
    {
        public UnifiedOrderResult(string key) : base(key)
        {
        }

        public string PrepayID { get; private set; }
        public string CodeUrl { get; private set; }
        protected override void ParseExtra()
        {
            this.PrepayID = this.data["prepay_id"];
            this.CodeUrl = this.data["code_url"];
        }
    }
}
