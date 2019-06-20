using Lsj.Util.Reflection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class StructProcesser : ObjectProcesser
    {
        public StructProcesser(Type type) : base(type)
        {

        }

        public override void Set(string name, object value)
        {
            if (properties.ContainsKey(name))
            {
                var property = properties[name];
                if (property.HasAttribute<CustomJsonPropertyNameAttribute>())
                {
                    if (Activator.CreateInstance(property.GetAttribute<CustomSerializeAttribute>().Serializer) is ISerializer serializer)
                    {
                        value = serializer.Parse(value);
                    }
                    else
                    {
                        JSONParser.Error("Custom Serializer Must Implement ISerializer");
                    }
                }
                var par = Expression.Parameter(result.GetType());
                var assign = Expression.Assign(Expression.Property(par, name), Expression.Constant(value));
                var expression = Expression.Lambda(Expression.Block(assign, par), par);
                var fuckingResult = expression.Compile().DynamicInvoke(result);
                result = fuckingResult;
            }
        }
    }
}
