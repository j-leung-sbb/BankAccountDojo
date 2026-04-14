namespace BankAccount
{
    public class BankAccount
    {
        private bool _acceptNegative;
        private decimal _balance;
        private readonly List<Transaction> _transactions = [];

        public BankAccount(bool acceptNegative = false)
        {
            _acceptNegative = acceptNegative;
        }


        public void Deposit(decimal amount)
        {
            if (amount <= 0m)
            {
                throw new InvalidOperationException();
            }

            _balance += amount;
            AddTransaction(TransactionType.Deposit, amount);
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Withdraw(decimal amount)
        {
            if (!_acceptNegative && amount > _balance || amount <= 0)
            {
                throw new InvalidOperationException();
            }


            _balance -= amount;
            AddTransaction(TransactionType.Withdraw, amount);
        }

        private void AddTransaction(TransactionType type, decimal amount)
        {
            _transactions.Add(new Transaction(type, amount));
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}
