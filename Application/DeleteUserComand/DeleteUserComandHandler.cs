using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DeleteUserComand
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
