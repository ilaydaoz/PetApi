using AutoMapper;
using Pet.Core.Application.Services.Commands.Insert.Users.Register;
using Pet.Core.Domain.Entities;

namespace Pet.Core.Application.Services.Commands.Insert.Category
{
    public class CategoryInsertCommandMapper : Profile
    {
        public CategoryInsertCommandMapper()
        {
            CreateMap<CategoryInsertCommandRequestModel,Domain.Entities.Category>();
            CreateMap<Domain.Entities.Category, CategoryInsertCommandResponse>();
        }
    }
}
