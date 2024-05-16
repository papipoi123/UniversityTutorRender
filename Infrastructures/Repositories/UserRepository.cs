using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }

        public Task<bool> ExistEmail(string email)
        {
            return _dbSet.AnyAsync(x => x.Email == email);
        }

        public async Task<User?> GetUserByCode(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.CodeResetPassword == code && x.IsDeleted == false);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email && x.IsDeleted == false);
        }

        public Task<User?> Login(string email, string password)
        {
            return _dbSet.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == email && x.Password == password && x.IsDeleted == false);
        }
    }
}
