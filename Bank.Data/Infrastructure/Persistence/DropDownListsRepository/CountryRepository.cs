using System.Linq;
using System.Threading.Tasks;
using Bank.Data.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Bank.Domain;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;

namespace Bank.Data.Infrastructure.Persistence.DropDownListsRepository
{
    public class CountryRepository : DropDownListRepository<Country>, ICountryRepository
    {
        public CountryRepository(BankContext bankContext) :base(bankContext)
        {

        }

        public async Task<Country> FindGenderTypeByGenderTypeId(string countryId)
        {
            return await Task.Run(() => BankDbContext.Countries
                .Where(g => g.CountryId == countryId)
                .ToList()
                .FirstOrDefault());

        }
    }
}
