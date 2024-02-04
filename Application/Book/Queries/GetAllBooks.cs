using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Queries
{
    public class GetAllBooks: IRequest<IList<BookEntity>>
    {
    }
}
