using Domain.Repositories;

namespace Application.UpdateUserComand
{
    public class UpdateUserComandHandler : IUpdateUserComandHandler
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task HandleAsync(UpdateUserComand comand, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserById(comand.Id, cancellationToken);
            if (userToUpdate is null)
            {
                throw new KeyNotFoundException();
            }
            await _userRepository.UpdateUser(userToUpdate, cancellationToken);
        }
    }
}
