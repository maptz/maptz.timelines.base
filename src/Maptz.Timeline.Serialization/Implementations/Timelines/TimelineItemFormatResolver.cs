//using System;
//using System.Reflection;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;

//namespace Maptz
//{

//    /// <summary>
//    /// var json = JsonConvert.SerializeObject(allLogs, Formatting.Indented, new JsonSerializerSettings{ ContractResolver = new TimelineItemFormatResolver() });
//    /// </summary>
//    public class TimelineItemFormatResolver : DefaultContractResolver
//    {
//        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
//        {
//            var baseProperty = base.CreateProperty(member, memberSerialization);
//            if (baseProperty.PropertyType != typeof(TimeCode))
//            {
//                return baseProperty;
//            }


//            return new JsonProperty
//            {
//                Readable = true,
//                ShouldSerialize = value => true,
//                PropertyName = baseProperty.PropertyName,
//                PropertyType = typeof(string),
//                Converter = ResolveContractConverter(typeof(string)),
//                ValueProvider = new TimeCodeValueProvider(member as PropertyInfo)
//            };

//        }
//    }
//}