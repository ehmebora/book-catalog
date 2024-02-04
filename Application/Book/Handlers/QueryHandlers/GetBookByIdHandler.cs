using Application.Abstractions;
using Application.Book.Queries;
using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Handlers.QueryHandlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookById, BookEntity>
    {
        private readonly IBookRepository _repository;

        public GetBookByIdHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public Task<BookEntity> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            return _repository.GetBookById(request.Id);
        }
    }
}
