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
        protected readonly JSONParser _parser;
        protected object? _result;
        protected Dictionary<string, PropertyInfo> _properties;

        public ObjectProcesser(JSONParser parser, Type type)
        {
            _parser = parser;
            _result = Activator.CreateInstance(type);
            _properties = type.GetProperties().Where(x => !x.HasAttribute<NotSerializeAttribute>())
                .ToDictionary(x => x.GetCustomAttribute<CustomJsonPropertyNameAttribute>()?.Name ?? x.Name, x => x);
        }

        public object? GetResult() => _result;

        public Type? GetValueType(string name)
        {
            if (_properties.ContainsKey(name))
            {
                var property = _properties[name];
                if (property.GetCustomAttribute<CustomSerializeAttribute>() is CustomSerializeAttribute attribute)
                {
                    return attribute.SourceType;
                }
                else
                {
                    return property.PropertyType;
                }
            }
            else if (!_parser.Settings.IgnoreNotExistsProperties)
            {
                throw new InvalidDataException($@"Error JSON string. Cannot find property ""{name}"".");
            }
            else if (!_parser.Settings.IsDebug)
            {
                _parser.Debug($@"Cannot find property ""{name}"".");
            }

            return null;
        }

        public virtual void Set(string name, object? value)
        {
            if (_properties.ContainsKey(name))
            {
                var property = _properties[name];
                if (property.CanWrite)
                {
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
                    else
                    {
                        property.SetValue(_result, value);
                    }
                }
                else if (!_parser.Settings.IgnoreNotWritableProperties)
                {
                    throw new InvalidDataException($@"Error JSON String. Cannot Write Property ""{name}"".");
                }
                else if (_parser.Settings.IsDebug)
                {
                    _parser.Debug($@"Cannot Write Property ""{name}"".");
                }
            }
        }

        public void SetNull() => _result = null;

        public void SetValue(object? value)
        {
            if (value is JSONObject obj)
            {
                foreach (var x in obj.Data)
                {
                    var processer = _parser.GetProcesserByType(GetValueType(x.Key));
                    processer.SetValue(x.Value);
                    Set(x.Key, processer.GetResult());
                }
            }
        }
    }
}
