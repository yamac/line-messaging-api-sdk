using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Yamac.LineMessagingApi.Utilities.Json
{
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override bool CanRead { get { return true; } }

        public override bool CanWrite { get { return false; } }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                if (reader.TokenType == JsonToken.EndArray)
                {
                    return null;
                }
                else
                {
                    var items = new List<T>();
                    while (reader.TokenType != JsonToken.EndArray)
                    {
                        items.Add((T)ReadJson(reader, objectType, existingValue, serializer));
                        reader.Read();
                    }
                    return items;
                }
            }
            else
            {
                var jsonObject = JObject.Load(reader);
                var item = Create(objectType, jsonObject);
                serializer.Populate(jsonObject.CreateReader(), item);
                return item;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected abstract T Create(Type objectType, JObject jsonObject);
    }
}
