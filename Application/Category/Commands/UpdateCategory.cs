using MediatR;
using CategoryEntity = Domain.Entities.Category;


namespace Application.Category.Commands
{
    public class UpdateCategory : IRequest<CategoryEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
