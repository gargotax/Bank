using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure
{
    public class UserRpository: IUserRepository
    {
        private static readonly Dictionary<Guid, User> _users = new Dictionary<Guid, User>();

        public Task<Guid> CreateUser(User user, CancellationToken cancellationToken)
        {
            _users.TryAdd(user.IdUser, user);

            return Task.FromResult(user.IdUser);
        }

        public Task DeleteUserById(Guid id, CancellationToken cancellationToken)
        {
            _users.Remove(id);
            return Task.CompletedTask;
        }

        public Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            _users.TryGetValue(id, out var user);
            return Task.FromResult(user);
        }

        public Task<bool> NhsNumberAlreadyExists(User user, CancellationToken cancellationToken)
        {
            foreach (var item in _users.Values)
            {
                if (item.NhsNumber == user.NhsNumber)
                {
                    return Task.FromResult(true);
                }               
            }
            return Task.FromResult(false);
        }
    }
}
