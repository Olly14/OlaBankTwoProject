using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data.Infrastructure.Persistence
{
    public abstract class DropDownListRepository<TEntity> : IDropDownListRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        private  DbSet<TEntity> _dbSet;

        public BankContext BankDbContext => _dbContext as BankContext;

        public DropDownListRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await Task.Run(() => _dbSet);
        }


        public async Task<TEntity> FindAsync(string id)
        {
            return await Task.Run(() => _dbSet.Find(id));
        }
    }
}
