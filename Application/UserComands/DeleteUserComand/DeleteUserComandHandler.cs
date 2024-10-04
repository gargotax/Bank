using Domain.Repositories;

namespace Application.UserComands.DeleteUserComand
{
    public class DeleteUserComandHandler : IDeleteUserComandHandler
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task HandleAsync(DeleteUserComand comand, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserById(comand.Id, cancellationToken);
        }
    }
}
