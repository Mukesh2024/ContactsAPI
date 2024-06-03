using ContactsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsApi.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddUserAsync(User user);
        Task EditUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
