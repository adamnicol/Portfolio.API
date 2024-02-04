using Portfolio.API.Data.Contracts;
using Portfolio.API.Data.Entities;

namespace Portfolio.API.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context)
            : base(context)
        {
        }

        public Task<User?> FindByUsername(string username)
        {
            return Find(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public Task<User?> FindByEmail(string email)
        {
            return Find(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
