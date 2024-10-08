using Domain.Entities;

namespace BaknApi.Models
{
    public record CreateAccountRequest(decimal Balance, decimal Overdraft, Account.AccountType AccountType, decimal MaxDepositAmountAllowed = 0);
    
    
}
