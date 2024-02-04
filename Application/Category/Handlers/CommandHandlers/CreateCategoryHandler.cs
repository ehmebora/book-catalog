using Application.Abstractions;
using Application.Category.Commands;
using MediatR;
using CategoryEntity = Domain.Entities.Category;


namespace Application.Category.Handlers.CommandHandlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, CategoryEntity>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryEntity> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var category = new CategoryEntity()
            {
                Name = request.Name
            };

            return await _repository.AddCategory(category);
        }
    }
}
