using Newtonsoft.Json;

namespace Frontend.Helpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// Use this to fix the json cycle error
        /// </summary>
        /// <param name="value">Your object to be formatted</param>
        /// <returns></returns>
        public static string FixCycle(object value)
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