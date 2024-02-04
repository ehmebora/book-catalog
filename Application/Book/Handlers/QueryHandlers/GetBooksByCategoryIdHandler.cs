using Application.Abstractions;
using Application.Book.Queries;
using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Handlers.QueryHandlers
{
    public class GetBooksByCategoryIdHandler : IRequestHandler<GetBooksByCategoryId, IList<BookEntity>>
    {
        private readonly IBookRepository _repository;

        public GetBooksByCategoryIdHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public Task<IList<BookEntity>> Handle(GetBooksByCategoryId request, CancellationToken cancellationToken)
        {
            return _repository.GetAllByCategoryId(request.CategoryId);
        }
    }
}
