using SharePaint.Models;
using System.Threading.Tasks;

namespace SharePaint.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(string id);
        Task<string> Login(User user);
    }
}
