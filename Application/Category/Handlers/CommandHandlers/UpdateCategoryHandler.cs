using MediatR;
using Application.Abstractions;
using Application.Category.Commands;
using CategoryEntity = Domain.Entities.Category;

namespace Application.Category.Handlers.CommandHandlers
{
    
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, CategoryEntity>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryEntity> Handle(UpdateCategory request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateCategory(request.Id, request.Name);
        }
    }
}
