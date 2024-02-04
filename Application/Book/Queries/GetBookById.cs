using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Queries
{
    public class GetBookById : IRequest<BookEntity>
    {
        public int Id { get; set; }

    }
}
