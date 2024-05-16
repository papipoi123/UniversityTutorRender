using Domain.Entities;

namespace Applications.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> Login(string email, string password);
        Task<bool> ExistEmail(string email);
        public Task<User?> GetUserByEmail(string email);
        public Task<User?> GetUserByCode(string code);
    }
}
