


using Domain.Entities;
using Domain.Repositories;

namespace Application.AccountComands
{
    public class CreateAccountHandler : ICreateAccountComandHandler
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        public CreateAccountHandler(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;

        }
        public async Task<Guid> HandleAsync(CreateAccountComand comand, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserById(comand.Iduser, cancellationToken);
            if (user is null)
            {
                throw new KeyNotFoundException();
            }

            Account account = new CurrentAccount(comand.Id, comand.Balance, comand.Overdraft);
            var accountId = await _accountRepository.CreateAccount(account, cancellationToken);
            return accountId;
        }
    }
}
