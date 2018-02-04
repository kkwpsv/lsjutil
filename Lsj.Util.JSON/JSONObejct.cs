using Lsj.Util.Collections;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Lsj.Util.JSON
{
    public class JSONObejct : DynamicObject
    {
        private SafeDictionary<string, object> data = new SafeDictionary<string, object>();


        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = binder.Name;
            if (data.ContainsKey(name))
            {
                result = data[name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            data[binder.Name] = value;
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = null;
            if (binder.Name == "Set" && args.Length == 2 && args[0] is string)
            {
                data[(string)args[0]] = args[1];
                return true;
            }
            else
            {
                return false;
            }
        }
        public override IEnumerable<string> GetDynamicMemberNames() => data.Keys;
    }
}
