using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain;

namespace Bank.Data.Infrastructure.Repository.IAppUserRepository
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<AppUser> FindAppUserWithAccountAsync(string userId);

        Task<IEnumerable<AppUser>> FindNonBlockedDeleteAppUsersAsync();

        Task<IEnumerable<AppUser>> FindNonBlockedDeleteAppUsersAsync(string id);
        bool isAdmin(System.Guid adminIdAsGuid, string ownerId);
        //object GetUser(string username, string password);
    }
}
