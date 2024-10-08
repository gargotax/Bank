
using Domain.Entities;
using Domain.Repositories;

namespace Application.AccountComands
{
    public class CreateAccountComandHandler : ICreateAccountComandHandler
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        public CreateAccountComandHandler(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }
        public async Task<Guid> HandleAsync(CreateAccountComand comand, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(comand.IdUser, cancellationToken);
            if (user == null)
            {
                throw new KeyNotFoundException();
            }

            Account account;
            if(comand.AccountType == Account.AccountType.SavingAccount)
            {
                 account = new SavingAccount(Guid.NewGuid(), comand.Balance, comand.MaxDepositAmountAllowed);
            }
            else 
            { 
                 account = new CurrentAccount(Guid.NewGuid(), comand.Balance, comand.Overdraft);
            }

            var accountId = await _accountRepository.CreateAccount(account, cancellationToken);
            return accountId;

        }
    }
}
