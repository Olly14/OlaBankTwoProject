using System.Threading.Tasks;
using Bank.Domain;


namespace Bank.Data.Infrastructure.Repository.IDropDownListsRepository
{
    public  interface ICountryRepository : IDropDownListRepository<Country>
    {
        Task<Country> FindGenderTypeByGenderTypeId(string countryId);
    }
}
