using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface  IUserRepository
    {
        Task<Guid> CreateUser(User user, CancellationToken cancellationToken);
        Task<bool> NhsNumberAlreadyExists(User user, CancellationToken cancellationToken);
    }

}
