using System.Text.Json;

namespace SportsStore.Infrastructure
{
    public static class SessionExtensions
    {
        public static T? GetJson<T>(this ISession session ,string key) 
        {
            string? jsonObject = session.GetString(key);

            return jsonObject is null ? default : JsonSerializer.Deserialize<T>(jsonObject)  ;
        }

        public static void SetJson(this ISession session, string key, object value) 
        {
            //serialize object
            string jsonObject = JsonSerializer.Serialize(value);
            session.SetString(key, jsonObject);
        }
    }
}
