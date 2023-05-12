﻿using Pet.Core.Application_.Repositories;
using Pet.Core.Domain.Entities;
using Pet.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EfDbContext context) : base(context)
        {
        }
    }
}