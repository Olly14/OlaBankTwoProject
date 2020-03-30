using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain
{

    public class CurrentAccount : Account
    {
        private double _currentRate;
        public CurrentAccount()
        {
            _currentRate = 1.5;
            Rate = _currentRate;
        }


        public CurrentAccount(Account account) :base(account)
        {
            _currentRate = 1.5;
            Rate = _currentRate;
        }
        public override void CalculateRate()
        {
            double interest = (this.CurrentBalance * Rate)/100;
            this.CurrentBalance += interest;
        }
    }
}
