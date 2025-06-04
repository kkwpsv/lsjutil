using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Lsj.Util.JSON.Processer
{
    class StructProcesser : ObjectProcesser
    {
        public StructProcesser(JSONParser parser, Type type) : base(parser, type)
        {

        }

        public override void Set(string name, object? value)
        {
            if (_properties.ContainsKey(name))
            {
                var property = _properties[name];
                if (property.GetCustomAttribute<CustomSerializeAttribute>() is CustomSerializeAttribute customSerializeAttribute)
                {
                    if (customSerializeAttribute.Serializer is null)
                    {
                        throw _parser.Error("Serializer cannot be null.");
                    }
                    if (Activator.CreateInstance(customSerializeAttribute.Serializer) is ISerializer serializer)
                    {
                        property.SetValue(_result, serializer.Parse(value));
                    }
                    else
                    {
                        throw _parser.Error("Custom serializer must implement ISerializer.");
                    }
                }
                var par = Expression.Parameter(_result!.GetType());
                var assign = Expression.Assign(Expression.Property(par, name), Expression.Constant(value));
                var expression = Expression.Lambda(Expression.Block(assign, par), par);
                var result = expression.Compile().DynamicInvoke(_result);
                _result = result;
            }
        }
    }
}
