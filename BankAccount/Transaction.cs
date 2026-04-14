namespace BankAccount
{
    public record Transaction(TransactionType Type, decimal amount)
    {
    }
}