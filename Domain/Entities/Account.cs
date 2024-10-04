namespace Domain.Entities
{
    public class Account
    {
        public Guid AccountId { get; }
        public decimal Balance { get; private set; }
        public Account(Guid accountId, decimal balance)
        {
            AccountId = accountId;
            Balance = balance;
        }
        public void Debit(decimal amount)
        {
            CheckPositiveAmount(amount);
            
            Balance -= amount;
        }
        public void Credit(decimal amount)
        {
            CheckPositiveAmount(amount);

            Balance += amount;
        }
        private static void CheckPositiveAmount(decimal amount)
        {
            if (amount < 0) throw new Exception();
        }
    }
}
