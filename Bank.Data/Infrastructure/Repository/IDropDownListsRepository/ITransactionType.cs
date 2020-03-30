using Bank.Data.Infrastructure.Persistence;
using Bank.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Infrastructure.Repository.IDropDownListsRepository
{
    public interface ITransactionType : IDropDownListRepository<TransactionType>
    {
        Task<TransactionType> FindByType(string txnType);
    }
}
