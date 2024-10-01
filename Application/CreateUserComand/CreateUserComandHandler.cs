﻿using Domain.Entities;
using Domain.Repositories;

namespace Application.CreateUserComand
{
    public class CreateUserComandHandler : ICreateUserComandHandler
    {
        private readonly IUserRepository _userRepository;
        public CreateUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> HandleAsync(CreateUserComand comand, CancellationToken cancellationToken)
        {
            User user = new(Guid.NewGuid(), comand.Name);

            await _userRepository.CreateUser(user, cancellationToken);
            return await Task.FromResult(user.IdUser);
        }
    }
}
