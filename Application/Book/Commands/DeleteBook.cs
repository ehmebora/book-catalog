using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Commands
{
    public class DeleteBook : IRequest
    {
        public int Id { get; set; }
    }
}
