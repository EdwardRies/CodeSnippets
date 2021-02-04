using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace HTH.Extensions
{
    public static partial class Extensions
    {
        /// 
        /// Converts an object into a serialized Json string. Many frameworks
        /// will do this automatically but in other cases this extension method 
        /// provides a simple solution. See FromJson extension for the ability 
        /// to easily cast the Json string back into an class/object.
        /// 
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CustomResolver(),
                    PreserveReferencesHandling = PreserveReferencesHandling.None
                });
        }

        /// 
        /// Used to avoid Entity Framework virtual property navigation. Entity objects 
        /// will not properly serialize without the CustomResolver.
        /// 
        class CustomResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);
                var propInfo = member as PropertyInfo;
                if (propInfo == null) return prop;
                if (propInfo.GetMethod.IsVirtual && !propInfo.GetMethod.IsFinal)
                {
                    prop.ShouldSerialize = obj => false;
                }
                return prop;
            }
        }

    }
}