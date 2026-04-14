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
        public void WithdrawMoreThanBalance_ShouldThrowException()
        {
            var bankAccount = new BankAccount();

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(50m));
        }
    }
}