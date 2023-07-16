using CoreStartApp.Models.Entities;
using System.Threading.Tasks;

namespace CoreStartApp.DAL
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();

        Task Remove(User user);

        Task<User> GetUser(int? index);
    }
}