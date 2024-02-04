using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Queries
{
    public class GetBooksByCategoryId : IRequest<IList<BookEntity>>
    {
        public int CategoryId { get; set; }
    }
}
