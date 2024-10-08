using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountComands
{
    public interface  ICreateAccountComandHandler
    {
        Task<Guid> HandleAsync(CreateAccountComand comand, CancellationToken cancellationToken);
    }
}
