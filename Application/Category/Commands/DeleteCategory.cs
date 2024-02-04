using MediatR;

namespace Application.Category.Commands
{
    public class DeleteCategory : IRequest
    {
        public int Id { get; set; }
    }
}
