using Pet.Core.Application_.Repositories;
using Pet.Core.Domain.Entities;
using Pet.Infrastructure.Context;

namespace Pet.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User, EfDbContext>, IUserRepository
    {
        public UserRepository(EfDbContext context) : base(context)
        {
        }
    }
}
