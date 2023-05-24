using AutoMapper;
using MediatR;
using Pet.Core.Application.Repositories;
using Pet.Core.Application.Services.Commands.Insert.Users.Register;

namespace Pet.Core.Application.Services.Commands.Insert.Category
{
    public class CategoryInsertCommandHandler : IRequestHandler<CategoryInsertCommandRequestModel, CategoryInsertCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryInsertCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryInsertCommandResponse> Handle(CategoryInsertCommandRequestModel request, CancellationToken cancellationToken)
        {
           
            var map = _mapper.Map<Domain.Entities.Category>(request);
            var categoryRepo = await _categoryRepository.InsertAsync(map);
            await _categoryRepository.SaveAsync();
            var categoryMap = _mapper.Map<CategoryInsertCommandResponse>(categoryRepo);
            return categoryMap;
          
        }
    }
}
