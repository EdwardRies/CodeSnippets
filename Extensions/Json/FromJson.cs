using Newtonsoft.Json;

namespace HTH.Extensions
{    
    public static partial class Extensions
    {
        /// 
        /// Deserializes a Json object to a class. See Newtonsoft 
        /// DeserializeObject for behavior details. See ToJson to 
        /// serializing objects as Json.
        /// 
        public static T FromJson(this string value)
        {
            return JsonConvert.DeserializeObject(value);
        }
    }
}