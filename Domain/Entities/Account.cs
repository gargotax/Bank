namespace Domain.Entities
{
    public abstract class Account
    {
        public Guid AccountId { get; }
        public decimal Balance { get; protected set; }
        public decimal Overdraft { get; private set; }
        public Account(Guid accountId, decimal balance, decimal overdraft = 0)
        {
            AccountId = accountId;
            Balance = balance;
            Overdraft = overdraft;
        }
        public enum AccountType
        {
            CurrentAccount = 0,
            SavingAccount  = 1,
        }
        public void Debit(decimal amount)
        {
            CheckPositiveAmount(amount);
            decimal balanceAfterWithdraft = Balance - amount;
            if (Overdraft > balanceAfterWithdraft) throw new Exception();   

            Balance -= amount;
        }
        public abstract void Credit(decimal amount);
        public void CheckPositiveAmount(decimal amount)
        {
            if (amount < 0) throw new Exception();
        }
    }
}
