using Lsj.Util.JSON.Processer.Interfaces;
using Lsj.Util.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lsj.Util.JSON.Processer
{
    class ObjectProcesser : IObjectProcesser, INullableProcesser
    {
        protected object _result;
        protected Dictionary<string, PropertyInfo> _properties;

        public ObjectProcesser(Type type)
        {
            _result = ReflectionHelper.CreateInstance(type);
            _properties = type.GetProperties().Where(x => !x.HasAttribute<NotSerializeAttribute>())
                .ToDictionary(x => x.HasAttribute<CustomJsonPropertyNameAttribute>() ? x.GetAttribute<CustomJsonPropertyNameAttribute>().Name : x.Name
                , x => x);
        }

        public object GetResult() => _result;

        public Type GetValueType(string name)
        {
            if (_properties.ContainsKey(name))
            {
                var property = _properties[name];
                if (property.HasAttribute<CustomSerializeAttribute>())
                {
                    return property.GetAttribute<CustomSerializeAttribute>().SourceType;
                }
                else
                {
                    return property.PropertyType;
                }
            }
            else if (!JSONParser.Settings.IgnoreNotExistsProperties)
            {
                throw new InvalidDataException($@"Error JSON String. Cannot Find Property ""{name}"".");
            }
            else if (!JSONParser.Settings.IsDebug)
            {
                JSONParser.Debug($@"Cannot Find Property ""{name}"".");
            }

            return null;
        }

        public virtual void Set(string name, object value)
        {
            if (_properties.ContainsKey(name))
            {
                var property = _properties[name];
                if (property.CanWrite)
                {
                    if (property.HasAttribute<CustomSerializeAttribute>())
                    {
                        if (Activator.CreateInstance(property.GetAttribute<CustomSerializeAttribute>().Serializer) is ISerializer serializer)
                        {
                            property.SetValue(_result, serializer.Parse(value));
                        }
                        else
                        {
                            throw new Exception("Custom Serializer Must Implement ISerializer");
                        }
                    }
                    else
                    {
                        property.SetValue(_result, value);
                    }
                }
                else if (!JSONParser.Settings.IgnoreNotWritableProperties)
                {
                    throw new InvalidDataException($@"Error JSON String. Cannot Write Property ""{name}"".");
                }
                else if (JSONParser.Settings.IsDebug)
                {
                    JSONParser.Debug($@"Cannot Write Property ""{name}"".");
                }
            }
        }

        public void SetNull() => _result = null;

        public void SetValue(object value)
        {
            if (value is JSONObject obj)
            {
                foreach (var x in obj.data)
                {
                    var processer = JSONParser.GetProcesserByType(this.GetValueType(x.Key));
                    processer.SetValue(x.Value);
                    Set(x.Key, processer.GetResult());
                }
            }
        }
    }
}
