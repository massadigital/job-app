using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JobApp.Common.Helpers
{
    public class JsonHelper
    {
        public static string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }
        public static T DeSerialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        public static T DeserializeOrDefault<T>(string value) where T : new()
        {
            T result;
            try
            {
                result = DeSerialize<T>(value);
            }
            catch (Exception)
            {
                result = new T();
            }
            return result;
        }
    }
}
