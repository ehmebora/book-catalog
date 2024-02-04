using MediatR;
using CategoryEntity = Domain.Entities.Category;

namespace Application.Category.Queries
{
    public class GetAllCategories : IRequest<IList<CategoryEntity>>
    {
    }
}
