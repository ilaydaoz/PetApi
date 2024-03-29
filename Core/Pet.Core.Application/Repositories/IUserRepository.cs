﻿using Pet.Core.Domain.Entities;
using Shared.Pet.Repositories;

namespace Pet.Core.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
