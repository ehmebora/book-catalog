using Application.Abstractions;
using Application.Category.Commands;
using MediatR;

namespace Application.Category.Handlers.CommandHandlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
            await _repository.DeleteCategory(request.Id);
        }
    }
}
