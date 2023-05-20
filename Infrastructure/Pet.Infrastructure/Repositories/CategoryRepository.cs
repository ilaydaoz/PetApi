﻿
using Pet.Core.Application.Repositories;
using Pet.Core.Domain.Entities;
using Pet.Infrastructure.Context;
using Shared.Pet.Repositories;

namespace Pet.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category,EfDbContext>, ICategoryRepository
    {
        public CategoryRepository(EfDbContext context) : base(context)
        {
        }
    }
}
