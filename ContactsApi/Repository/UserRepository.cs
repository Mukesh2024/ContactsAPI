using ContactsApi.Helper;
using ContactsApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await JsonFileHelper.ReadJsonFileAsync();
        }

        public async Task AddUserAsync(User user)
        {
            var users = await JsonFileHelper.ReadJsonFileAsync();
            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
            await JsonFileHelper.WriteJsonFileAsync(users);
        }

        public async Task EditUserAsync(User user)
        {
            var users = await JsonFileHelper.ReadJsonFileAsync();
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                await JsonFileHelper.WriteJsonFileAsync(users);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var users = await JsonFileHelper.ReadJsonFileAsync();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
                await JsonFileHelper.WriteJsonFileAsync(users);
            }
        }
    }
}
