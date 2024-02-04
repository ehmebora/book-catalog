using MediatR;
using CategoryEntity = Domain.Entities.Category;

namespace Application.Category.Queries
{
    public class GetCategoryById : IRequest<CategoryEntity>
    {
        public int Id { get; set; }
    }
}
