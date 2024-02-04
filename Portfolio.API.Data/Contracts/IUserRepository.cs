using Portfolio.API.Data.Entities;

namespace Portfolio.API.Data.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> FindByUsername(string username);
        Task<User?> FindByEmail(string email);
    }
}
