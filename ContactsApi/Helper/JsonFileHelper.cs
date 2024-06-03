using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ContactsApi.Models;

namespace ContactsApi.Helper
{
    public static class JsonFileHelper
    {
        private static readonly string JsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "users.json");

        public static async Task<List<User>> ReadJsonFileAsync()
        {
            if (!File.Exists(JsonFilePath))
            {
                return new List<User>();
            }

            var json = await File.ReadAllTextAsync(JsonFilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public static async Task WriteJsonFileAsync(List<User> users)
        {
            var json = JsonSerializer.Serialize(users);
            await File.WriteAllTextAsync(JsonFilePath, json);
        }
    }
}
