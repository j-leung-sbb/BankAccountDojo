namespace BankAccount.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void NewAccount_ShouldHaveZeroBalance()
        {
            var bankAccount = new BankAccount();

            Assert.AreEqual(0m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void Deposit_ShouldIncreaseBalance()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);

            Assert.AreEqual(100m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void MultipleDeposits_ShouldAccumulateBalance()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);
            bankAccount.Deposit(200m);

            Assert.AreEqual(300m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void Withdraw_ShouldDecreaseBalance()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(200m);
            bankAccount.Withdraw(100m);

            Assert.AreEqual(100m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void DepositAndWithdraw_ShouldResultInCorrectBalance()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(200m);
            bankAccount.Withdraw(50m);
            bankAccount.Deposit(25m);

            Assert.AreEqual(175m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void WithdrawMoreThanBalance_ShouldThrowException()
        {
            var bankAccount = new BankAccount();

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(50m));
        }

        [TestMethod]
        public void WithdrawExactBalance_ShouldResultInZeroBalance()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);
            bankAccount.Withdraw(100m);

            Assert.AreEqual(0m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void AcceptNegativeAccountBalance_ShouldAllowNegativeBalance()
        {
            var bankAccount = new BankAccount(true);

            bankAccount.Deposit(100m);
            bankAccount.Withdraw(150m);

            Assert.AreEqual(-50m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void DisallowNegativeDeposits()
        {
            var bankAccount = new BankAccount(true);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(-50m));
        }

        [TestMethod]
        public void DisallowNegativeWithdraws()
        {
            var bankAccount = new BankAccount(true);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(-50m));
        }

        [TestMethod]
        public void DepositZero_ShouldNotChangeBalance()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(0m);

            Assert.AreEqual(0m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void WithdrawZero_ShouldNotChangeBalance()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);
            bankAccount.Withdraw(0m);

            Assert.AreEqual(100m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void DecimalAmounts_ShouldBeProcessedCorrectly()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(10.50m);
            bankAccount.Withdraw(2.25m);

            Assert.AreEqual(8.25m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void SmallAmounts_ShouldBeProcessedCorrectly()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(0.01m);
            bankAccount.Deposit(0.02m);
            bankAccount.Withdraw(0.01m);

            Assert.AreEqual(0.02m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void MultipleDepositsAndWithdrawals_ShouldKeepCorrectBalance()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);
            bankAccount.Withdraw(25m);
            bankAccount.Deposit(50m);
            bankAccount.Withdraw(10m);
            bankAccount.Deposit(5m);

            Assert.AreEqual(120m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void Balance_ShouldRemainConsistentAfterManyOperations()
        {
            var bankAccount = new BankAccount();

            for (var i = 0; i < 100; i++)
            {
                bankAccount.Deposit(10m);
            }

            for (var i = 0; i < 50; i++)
            {
                bankAccount.Withdraw(5m);
            }

            Assert.AreEqual(750m, bankAccount.GetBalance());
        }

        [TestMethod]
        public void NewAccount_ShouldHaveZeroTransactions()
        {
            var bankAccount = new BankAccount();

            Assert.IsEmpty(bankAccount.GetTransactions());
        }

        [TestMethod]
        public void Deposit_ShouldRecordTransaction()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);

            var transactions = bankAccount.GetTransactions();

            Assert.HasCount(1, transactions);
        }

        [TestMethod]
        public void Deposit_ShouldRecordTransactionWithTypeAndAmount()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);

            var transaction = bankAccount.GetTransactions().Single();
            var expected = new Transaction(TransactionType.Deposit, 100m);

            Assert.AreEqual(expected, transaction);
        }

        [TestMethod]
        public void Withdraw_ShouldRecordTransaction()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);
            bankAccount.Withdraw(50m);

            var transaction = bankAccount.GetTransactions().Last();
            var expected = new Transaction(TransactionType.Withdraw, 50m);

            Assert.AreEqual(expected, transaction);
        }

        [TestMethod]
        public void Deposit_ShouldRecordTransactionWithEnum()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);

            var transaction = bankAccount.GetTransactions().Single();

            Assert.AreEqual(TransactionType.Deposit, transaction.Type);
        }

        [TestMethod]
        public void Transactions_ShouldBeStoredInOrder()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);
            bankAccount.Withdraw(25m);
            bankAccount.Deposit(50m);

            var transactions = bankAccount.GetTransactions();

            Assert.AreEqual(new Transaction(TransactionType.Deposit, 100m), transactions[0]);
            Assert.AreEqual(new Transaction(TransactionType.Withdraw, 25m), transactions[1]);
            Assert.AreEqual(new Transaction(TransactionType.Deposit, 50m), transactions[2]);
        }

        [TestMethod]
        public void Account_ShouldReturnStatement()
        {
            var bankAccount = new BankAccount();

            var statement = bankAccount.GetStatement();

            Assert.Contains("Statement", statement);
        }

        [TestMethod]
        public void Statement_ShouldContainAllTransactions()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);
            bankAccount.Withdraw(25m);

            var statement = bankAccount.GetStatement();

            Assert.Contains("Deposit: 100", statement);
            Assert.Contains("Withdraw: 25", statement);
        }

        [TestMethod]
        public void Statement_ShouldContainCurrentBalance()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);
            bankAccount.Withdraw(25m);

            var statement = bankAccount.GetStatement();

            Assert.Contains("Balance: 75", statement);
        }

        [TestMethod]
        public void Statement_ShouldShowTransactionsInCorrectOrder()
        {
            var bankAccount = new BankAccount();

            bankAccount.Deposit(100m);
            bankAccount.Withdraw(25m);
            bankAccount.Deposit(50m);

            var statement = bankAccount.GetStatement();

            var deposit100Index = statement.IndexOf("Deposit: 100", StringComparison.Ordinal);
            var withdraw25Index = statement.IndexOf("Withdraw: 25", StringComparison.Ordinal);
            var deposit50Index = statement.IndexOf("Deposit: 50", StringComparison.Ordinal);

            Assert.IsLessThan(withdraw25Index, deposit100Index);
            Assert.IsLessThan(deposit50Index, withdraw25Index);
        }
    }
}