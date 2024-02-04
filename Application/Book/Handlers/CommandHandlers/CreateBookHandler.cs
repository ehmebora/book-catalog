using Application.Abstractions;
using Application.Book.Commands;
using MediatR;
using BookEntity = Domain.Entities.Book;


namespace Application.Book.Handlers.CommandHandlers
{
    public class CreateBookHandler : IRequestHandler<CreateBook, BookEntity>
    {
        private readonly IBookRepository _repository;

        public CreateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<BookEntity> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var book = new BookEntity()
            {
                CategoryId = request.CategoryId,
                Title = request.Title ?? "",
                Description = request.Description ?? "",
                PublicDateUtc = request.PublicDateUtc.HasValue ? request.PublicDateUtc.Value : DateTime.Now
            };

            return await _repository.AddBook(book);
        }
    }
}
