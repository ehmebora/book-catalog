using Application.Abstractions;
using Application.Book.Queries;
using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Handlers.QueryHandlers
{
    public class GetBooksByCategoryIdHandler : IRequestHandler<GetBooksByCategoryId, PagedList<BookEntity>>
    {
        private readonly IBookRepository _repository;

        public GetBooksByCategoryIdHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<PagedList<BookEntity>> Handle(GetBooksByCategoryId request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllByCategoryId(request.CategoryId, request.SearchTerm, request.SortColumn, request.SortOrder, request.Page, request.PageSize);
        }
    }
}
