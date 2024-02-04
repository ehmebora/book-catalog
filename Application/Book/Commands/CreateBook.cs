using MediatR;
using BookEntity = Domain.Entities.Book;

namespace Application.Book.Commands
{
    public class CreateBook : IRequest<BookEntity>
    {
        public int CategoryId { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime? PublicDateUtc { get; set; } = DateTime.Now;
    }
}
