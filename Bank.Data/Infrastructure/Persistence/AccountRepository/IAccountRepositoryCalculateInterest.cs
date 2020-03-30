using System.Threading.Tasks;
using Bank.Domain;

namespace Bank.Data.Infrastructure.Persistence.AccountRepository
{
    public interface IAccountRepositoryCalculateInterest
    {
        Task<Account> CalculateInterestAsync(Account account);
    }
}