namespace BankAccount
{
    public class BankAccount
    {
        private readonly bool _acceptNegative;
        private decimal _balance;
        private readonly List<Transaction> _transactions = [];

        public BankAccount(bool acceptNegative = false)
        {
            _acceptNegative = acceptNegative;
        }


        public void Deposit(decimal amount)
        {
            if (amount < 0m)
            {
                throw new InvalidOperationException();
            }

            if (amount == 0m)
            {
                return;
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
            if (amount < 0m)
            {
                throw new InvalidOperationException();
            }

            if (amount == 0m)
            {
                return;
            }

            if (!_acceptNegative && amount > _balance)
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