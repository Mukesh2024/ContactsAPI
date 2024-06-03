using ContactsApi.Models;

namespace ContactsApi.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddUserAsync(User user);
        Task EditUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
