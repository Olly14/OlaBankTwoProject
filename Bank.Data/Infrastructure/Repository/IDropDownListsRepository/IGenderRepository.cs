using System.Threading.Tasks;
using Bank.Domain;



namespace Bank.Data.Infrastructure.Repository.IDropDownListsRepository
{
    public interface IGenderRepository : IDropDownListRepository<Gender>
    {
        Task<Gender> FindGenderTypeByGenderTypeId(string genderId);
    }
}
