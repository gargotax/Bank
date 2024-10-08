using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Guid> CreateAccount(Account account, CancellationToken cancellationToken);
    }
}
