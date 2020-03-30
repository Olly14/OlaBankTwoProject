using Bank.Data.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Data.Infrastructure.Persistence
{
    public class UnitOfWorkB<TEntity> : IUnitOfWorkB<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        private DbSet<TEntity> _dbSet;

        public BankContext BankDbContext => DbContext as BankContext;

        protected UnitOfWorkB(DbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TEntity>();
        }

        public async Task<TEntity> UpdateAsync(CancellationToken cancellationToken,TEntity entity)
        {
            var newAttachedAccount = _dbSet.Attach(entity);
            newAttachedAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this.CommitAsync(cancellationToken);
            return entity;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
