using Lsj.Util.JSON.Processer.Interfaces;
using Lsj.Util.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class ObjectProcesser : IObjectProcesser, INullableProcesser
    {
        protected object result;
        protected Dictionary<string, PropertyInfo> properties;

        public ObjectProcesser(Type type)
        {
            result = ReflectionHelper.CreateInstance(type);
            properties = type.GetProperties().Where(x => !x.HasAttribute<NotSerializeAttribute>())
                .ToDictionary(x => x.HasAttribute<CustomJsonPropertyNameAttribute>() ? x.GetAttribute<CustomJsonPropertyNameAttribute>().Name : x.Name
                , x => x
                );
        }

        public object GetResult() => result;

        public Type GetValueType(string name)
        {
            if (properties.ContainsKey(name))
            {
                var property = properties[name];
                if (property.HasAttribute<CustomSerializeAttribute>())
                {
                    return property.GetAttribute<CustomSerializeAttribute>().SourceType;
                }
                else
                {
                    return property.PropertyType;
                }
            }
            else
            {
                JSONParser.Warn($@"Error JSON String. Cannot Find Property ""{name}"".");
            }
            return null;
        }

        public virtual void Set(string name, object value)
        {
            if (properties.ContainsKey(name))
            {
                var property = properties[name];
                if (property.HasAttribute<CustomSerializeAttribute>())
                {
                    if (Activator.CreateInstance(property.GetAttribute<CustomSerializeAttribute>().Serializer) is ISerializer serializer)
                    {
                        property.SetValue(result, serializer.Parse(value));
                    }
                    else
                    {
                        JSONParser.Error("Custom Serializer Must Implement ISerializer");
                    }
                }
                else
                {
                    property.SetValue(result, value);
                }
            }
        }

        public void SetNull() => result = null;

        public void SetValue(object value)
        {
            if (value is JSONObject obj)
            {
                foreach (var x in obj.data)
                {
                    var processer = JSONParser.GetProcesserByType(this.GetValueType(x.Key));
                    processer.SetValue(x.Value);
                    this.Set(x.Key, processer.GetResult());
                }
            }
        }
    }
}
