using Application.Abstractions;
using Application.Category.Queries;
using MediatR;
using CategoryEntity = Domain.Entities.Category;

namespace Application.Category.Handlers.QueryHandlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryById, CategoryEntity>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<CategoryEntity> Handle(GetCategoryById request, CancellationToken cancellationToken)
        {
            return await _repository.GetCategoryById(request.Id);
        }
    }
}
