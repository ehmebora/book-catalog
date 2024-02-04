using Application.Abstractions;
using Application.Category.Queries;
using MediatR;
using CategoryEntity = Domain.Entities.Category;


namespace Application.Category.Handlers.QueryHandlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, IList<CategoryEntity>>
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoriesHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public Task<IList<CategoryEntity>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
