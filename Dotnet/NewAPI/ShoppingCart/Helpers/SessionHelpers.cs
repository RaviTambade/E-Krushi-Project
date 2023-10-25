using System.Text.Json;

namespace Transflower.EKrushi.ShoppingCartService.Helpers
{
    public static class SessionHelper
    {
        public static async Task SetObjectAsJson(this ISession session, string key, object value)
        {
            var json = JsonSerializer.Serialize(value);
            await session.LoadAsync();
            session.SetString(key, json);
            await session.CommitAsync();
        }

        public static async Task<T?> GetObjectFromJson<T>(this ISession session, string key)
        {
            await session.LoadAsync();
            var value = session.GetString(key);
            Console.WriteLine(key);
            Console.WriteLine(value);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
