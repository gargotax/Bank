using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DeleteUserComand
{
    public class DeleteUserComand
    {
        public Guid Id { get;}
        public DeleteUserComand(Guid id)
        {
            Id = id;
        }
    }
}
