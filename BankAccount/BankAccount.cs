namespace BankAccount
{
    public class BankAccount
    {
        private decimal _balance;

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > _balance)
            {
                throw new InvalidOperationException();
            }

            _balance -= amount;
        }
    }
}
