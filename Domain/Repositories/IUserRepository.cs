using Domain.Entities;

namespace Domain.Repositories
{
    public interface  IUserRepository
    {
        Task<Guid> CreateUser(User user, CancellationToken cancellationToken);
        Task<User?> GetUserById(Guid id, CancellationToken cancellationToken);
        Task DeleteUserById(Guid id, CancellationToken cancellationToken);
        Task<bool> NhsNumberAlreadyExists(User user, CancellationToken cancellationToken);
    }

}
