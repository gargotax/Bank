namespace Domain.Entities
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(Guid accountId, decimal balance, decimal overdraft) : base(accountId, balance, overdraft)
        {
        }

        public override void Credit(decimal amount)
        {
            CheckPositiveAmount(amount);
            Balance += amount;
        }
    }
}
