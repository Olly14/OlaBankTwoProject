using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Data.Infrastructure.Repository.IAppUserRepository;
using Bank.Domain;
using Microsoft.EntityFrameworkCore;


namespace Bank.Data.Infrastructure.Persistence.AppUSerRepository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(BankContext bankContext) : base(bankContext)
        {

        }

        public async Task<AppUser> FindAppUserWithAccountAsync(string userId)
        {
            return  await Task.Run(() => BankDbContext.AppUsers
                .Where(au => au.Id.Equals(userId) && au.IsDeleted != true && au.IsBlocked != true)
                .Include(au => au.Accounts)
                .SingleOrDefault());
                        
        }

        public async Task<IEnumerable<AppUser>> FindNonBlockedDeleteAppUsersAsync()
        {
            return await Task.Run(() => BankDbContext.AppUsers
                .Where(a => a.IsDeleted != true && a.IsBlocked != true)
                .ToList());
        }

        public async Task<IEnumerable<AppUser>> FindNonBlockedDeleteAppUsersAsync(string id)
        {
            return await Task.Run(() => BankDbContext.AppUsers
                .Where( a => a.IsDeleted != true && a.IsBlocked != true).Where(a => a.Id == id)
                .ToList());
        }


        public bool isAdmin(System.Guid adminIdAsGuid, string ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
