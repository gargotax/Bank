using Domain.Entities;
using Domain.Repositories;

namespace Application.UserComands.GetUserComand
{
    public class GetUserComandHandler : IGetUserComandHandler
    {
        private readonly IUserRepository _userRepository;
        public GetUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> HandleAsync(GetUserComand comand, CancellationToken cancellationToken)
        {
            User? userToGet = await _userRepository.GetUserById(comand.Id, cancellationToken);
            if (userToGet is null)
            {
                throw new KeyNotFoundException();
            }

            return userToGet;
        }
    }
}
