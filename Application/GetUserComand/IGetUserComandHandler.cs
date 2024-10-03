using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GetUserComand
{
    public interface  IGetUserComandHandler
    {
        Task<User> HandleAsync(GetUserComand comand, CancellationToken cancellationToken);
    }
}
