using Application.Abstractions;
using Application.Book.Commands;
using MediatR;


namespace Application.Book.Handlers.CommandHandlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBook>
    {
        private readonly IBookRepository _repository;

        public DeleteBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            await _repository.DeleteBook(request.Id);
        }
    }
}
