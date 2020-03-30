using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.DatabasePopulated
{
    public interface IPopulateDatabaseWithData
    {
        bool IsSeeded();

        void EnsureSeedDataContext();
    }
}
