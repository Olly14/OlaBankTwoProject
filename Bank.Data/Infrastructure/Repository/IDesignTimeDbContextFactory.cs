using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Infrastructure.Repository
{
    public interface IDesignTimeDbContextFactory<TEntity> where TEntity : class
    {
    }
}
