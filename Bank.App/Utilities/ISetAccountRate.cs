using System.Threading.Tasks;
using Bank.App.Models;
using Bank.Domain;

namespace Bank.App.Utilities
{
    public interface ISetAccountRate
    {
        Task<AccountViewModel> SetRateAsync(AccountViewModel account);
    }
}