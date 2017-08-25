using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Reflection;

namespace Yamac.LineMessagingApi.Models.Utilities.Json
{
    public class JsonEpochMillisDateTimeConverter : DateTimeConverterBase
    {
        private readonly DateTime _epochBase = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long epochMillis;

            if (value is DateTime dateTime)
            {
                DateTime utcDateTime = dateTime.ToUniversalTime();
                epochMillis = (long)(utcDateTime - _epochBase).TotalMilliseconds;
            }
            else if (value is DateTimeOffset dateTimeOffset)
            {
                DateTimeOffset utcDateTimeOffset = dateTimeOffset.ToUniversalTime();
                epochMillis = (long)(utcDateTimeOffset.UtcDateTime - _epochBase).TotalMilliseconds;
            }
            else
            {
                throw new JsonSerializationException("Expected date object value.");
            }

            writer.WriteValue(epochMillis);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                if (!IsNullable(objectType))
                {
                    throw new JsonSerializationException($"Cannot convert null value to {objectType}");
                }

                return null;
            }

            if (reader.TokenType != JsonToken.Integer)
            {
                throw new JsonSerializationException($"Unexpected token parsing date. Expected Integer, got {reader.TokenType}.");
            }

            long epochMillis = (long)reader.Value;

            DateTime d = _epochBase.AddMilliseconds(epochMillis);

            Type t = (IsNullableType(objectType))
                ? Nullable.GetUnderlyingType(objectType)
                : objectType;
            if (t == typeof(DateTimeOffset))
            {
                return new DateTimeOffset(d);
            }
            return d;
        }

        private static bool IsNullable(Type t)
        {
            if (t.GetTypeInfo().IsValueType)
            {
                return IsNullableType(t);
            }

            return true;
        }

        private static bool IsNullableType(Type t)
        {
            return (t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
