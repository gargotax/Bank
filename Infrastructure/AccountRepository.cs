using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure
{
    public class AccountRepository : IAccountRepository
    {
        private static readonly Dictionary<Guid,Account> _accounts = new ();
        public Task<Guid> CreateAccount(Account account, CancellationToken cancellationToken)
        {
            _accounts.TryAdd(account.AccountId, account);
            return Task.FromResult(account.AccountId);
        }
    }
}
