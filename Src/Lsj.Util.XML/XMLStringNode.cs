using Lsj.Util.Text;
using System;
using System.Collections.Generic;
namespace Lsj.Util.XML
{
    public class XMLStringNode : XMLNode
    {
        public override List<XMLNode> Childeren => throw new InvalidOperationException();
        public override List<XMLAttribute> Attributes => throw new InvalidOperationException();
        public override string Name
        {
            get
            {
                throw new InvalidOperationException();
            }

            set
            {
                throw new InvalidOperationException();
            }
        }
        public string Content { get; set; }
        public bool IsCDATA { get; set; } = false;
        public override string ToString() => this.IsCDATA ? $"<![CDATA[{this.Content.ToSafeString()}]]>" : this.Content.ToSafeString();
    }
}
