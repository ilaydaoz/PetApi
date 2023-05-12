using Pet.Core.Domain.Entities;
using Shared.Pet.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Core.Application_.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
