using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EducationPortal.Infrastructure
{
    internal class JsonSerializer<T>
    {
        public string SerializeItem(List<T> item)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string result = JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return result;
        }

        public List<T> DecerializeItem(string serializedItem)
        {
            List<T> item = JsonConvert.DeserializeObject<List<T>>(serializedItem);
            return item;
        }
    }
}
