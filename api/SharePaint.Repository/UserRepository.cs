using SharePaint.Models;
using SharePaint.Repository.Interfaces;

namespace SharePaint.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbShapeContext context) : base(context)
        {
        }
    }
}
