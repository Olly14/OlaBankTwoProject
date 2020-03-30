using System.Linq;
using System.Threading.Tasks;
using Bank.Data.Infrastructure.Repository;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Microsoft.EntityFrameworkCore;
using Bank.Domain;


namespace Bank.Data.Infrastructure.Persistence.DropDownListsRepository
{
    public class GenderRepository : DropDownListRepository<Gender>, IGenderRepository
    {
        public GenderRepository(BankContext bankContext) : base(bankContext)
        {
            
        }

        public async Task<Gender> FindGenderTypeByGenderTypeId(string genderId)
        {
            return await Task.Run(() => BankDbContext.Genders
                .Where(g => g.GenderId == genderId)
                .ToList()
                .FirstOrDefault());

        }

    }
}
