

namespace Bank.Domain
{
    public class SavingAccount : Account
    {
        private double _savingRate;
        public SavingAccount()
        {
            _savingRate = 3.0;
            Rate = _savingRate;
        }

        public SavingAccount(Account account) : base(account)
        {
            
            _savingRate = 3.0;
            Rate = _savingRate;
        }


        public override void CalculateRate()
        {
            double interest = (this.CurrentBalance * Rate)/100;
            this.CurrentBalance += interest;
        }
    }
}
