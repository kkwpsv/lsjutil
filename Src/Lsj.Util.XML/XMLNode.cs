using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.XML
{
    public class XMLNode
    {
        public virtual string Name { get; set; }
        public virtual List<XMLNode> Childeren { get; } = new List<XMLNode>();
        public virtual List<XMLAttribute> Attributes { get; } = new List<XMLAttribute>();
        public override string ToString()
        {
            if (this.Childeren.Count == 0 && this.Attributes.Count == 0)
            {
                return $"</{this.Name}>";
            }
            var result = new StringBuilder();
            result.Append("<");
            result.Append(this.Name);

            if (this.Attributes.Count > 0)
            {
                foreach (var attribute in this.Attributes)
                {
                    result.Append(" ");
                    result.Append(attribute.ToString());
                }
            }

            result.Append(">");

            if (this.Childeren.Count > 0)
            {
                foreach (var child in this.Childeren)
                {
                    result.Append(child.ToString());
                }
            }


            result.Append("<");
            result.Append(this.Name);
            result.Append("/>");
            return result.ToString();
        }
    }
}
