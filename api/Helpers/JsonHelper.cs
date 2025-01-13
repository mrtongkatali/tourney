using Newtonsoft.Json;

namespace tourney.api.Helpers
{
    public static class JsonHelper 
    {
        public static string SerializeModel(object model)
        {
            return JsonConvert.SerializeObject(model, Formatting.Indented);
        }
    }
}