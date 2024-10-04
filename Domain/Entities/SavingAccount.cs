

namespace Domain.Entities
{
    public class SavingAccount : Account
    {
        public decimal MaxCreditAmountAllowed { get;}
        public SavingAccount(Guid accountId, decimal balance, decimal maxCreditAmountAllowed) : base(accountId, balance)
        {
            MaxCreditAmountAllowed = maxCreditAmountAllowed;
        }

        public override void Credit(decimal amount)
        {
            CheckPositiveAmount(amount);
            if (amount > MaxCreditAmountAllowed)
            {
                throw new Exception();
            }
            Balance += amount;
        }
    }
}
