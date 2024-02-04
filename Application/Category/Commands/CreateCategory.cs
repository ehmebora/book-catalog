using MediatR;
using CategoryEntity = Domain.Entities.Category;

namespace Application.Category.Commands
{
    public class CreateCategory : IRequest<CategoryEntity>
    {
        public string Name { get; set; } = string.Empty;
    }
}
