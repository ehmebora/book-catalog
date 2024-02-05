using MediatR;

namespace Application.Book.Commands
{
    public class DeleteBook : IRequest
    {
        public int Id { get; set; }
    }
}
