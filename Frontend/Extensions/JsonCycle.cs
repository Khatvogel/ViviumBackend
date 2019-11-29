using Newtonsoft.Json;

namespace Frontend.Extensions
{
    public static class JsonCycle
    {
        public static string Fix(object value)
        {
            return JsonConvert.SerializeObject(value,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                });
        }
    }
}