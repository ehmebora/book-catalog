using Application.Abstractions;
using Application.Book.Queries;
using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Handlers.QueryHandlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooks, PagedList<BookEntity>>
    {
        private readonly IBookRepository _repository;

        public GetAllBooksHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<PagedList<BookEntity>> Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll(request.SearchTerm, request.SortColumn, request.SortOrder, request.Page, request.PageSize);
        }
    }
}
