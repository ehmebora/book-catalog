using Application.Abstractions;
using Application.Book.Commands;
using FluentValidation;
using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Handlers.CommandHandlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBook, BookEntity>
    {
        private readonly IBookRepository _repository;

        public UpdateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<BookEntity> Handle(UpdateBook request, CancellationToken cancellationToken)
        {
            UpdateBookValidator validator = new UpdateBookValidator();
            validator.ValidateAndThrow(request);

            var book = new BookEntity()
            {
                CategoryId = request.CategoryId,
                Title = request.Title,
                Description = request.Description,
                PublicDateUtc = request.PublicDateUtc
            };

            return await _repository.UpdateBook(request.Id, book);
        }
    }
}
