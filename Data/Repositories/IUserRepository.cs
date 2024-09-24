using Microsoft.EntityFrameworkCore;
using tourismApp.Models.Entities;

namespace tourismApp.Data.Repositories
{   
    public interface IUserRepository
    {
    Task<User> GetUserById(int id);
    Task<IEnumerable<User>> GetAllUsers();
    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);

   }
}
