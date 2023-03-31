﻿using ECommerceLP.Common.Collections.Abstract;
using ECommerceLP.Common.Collections.Concrete;
using ECommerceLP.Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Serialization.Converters
{
    public class PagedListConverter:JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var jsonSerializer = new JsonSerializer
            {
                ContractResolver = serializer.ContractResolver,
                Formatting = serializer.Formatting,
            };
            jsonSerializer.Converters.Add(new StringEnumConverter());
            var jobject = JToken.FromObject(value, jsonSerializer);
            writer.WriteToken(jobject.CreateReader());
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
            JsonSerializer serializer)
        {
            var dtoType = objectType.GenericTypeArguments[0];
            var resultType = typeof(PagedList<>).MakeGenericType(dtoType);
            var jsonSerializer = new JsonSerializer
            {
                ContractResolver = serializer.ContractResolver,
                Formatting = serializer.Formatting,
            };
            jsonSerializer.Converters.Add(new StringEnumConverter());
            return JToken.Load(reader).ToObject(resultType, jsonSerializer);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableToGenericType(typeof(IPagedList<>));
        }
    }
}
