using MediatR;
using Pet.Core.Application.Services.Commands.Insert.Users.Register;

namespace Pet.Core.Application.Services.Commands.Insert.Category
{
    public class CategoryInsertCommandRequestModel : IRequest<CategoryInsertCommandResponse>
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }             
    }
}
