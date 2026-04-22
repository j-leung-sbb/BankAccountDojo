namespace BankAccount
{
    public class BankAccount
    {
        private readonly bool _acceptNegative;
        private readonly decimal? _overdraftLimit;
        private decimal _balance;
        private readonly List<Transaction> _transactions = new();

        public BankAccount(bool acceptNegative = false, decimal? overdraftLimit = null)
        {
            _acceptNegative = acceptNegative;
            _overdraftLimit = overdraftLimit;
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

            var newBalance = _balance - amount;

            if (!_acceptNegative && newBalance < 0m)
            {
                throw new InvalidOperationException();
            }

            if (_acceptNegative && _overdraftLimit.HasValue && newBalance < -_overdraftLimit.Value)
            {
                throw new InvalidOperationException();
            }

            _balance = newBalance;
            AddTransaction(TransactionType.Withdraw, amount);
        }

        public void TransferTo(BankAccount targetAccount, decimal amount)
        {
            Withdraw(amount);
            targetAccount.Deposit(amount);
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }

        public string GetStatement()
        {
            var statementLines = new List<string>
            {
                "Statement"
            };

            foreach (var transaction in _transactions)
            {
                statementLines.Add($"{transaction.Type}: {transaction.amount}");
            }

            statementLines.Add($"Balance: {_balance}");

            return string.Join(Environment.NewLine, statementLines);
        }

        private void AddTransaction(TransactionType type, decimal amount)
        {
            _transactions.Add(new Transaction(type, amount));
        }
    }
}