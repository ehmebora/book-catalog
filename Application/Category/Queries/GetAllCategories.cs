using MediatR;
using CategoryEntity = Domain.Entities.Category; 

namespace Application.Category.Queries
{
    public class GetAllCategories : IRequest<PagedList<CategoryEntity>>, IPaging
    {
        private readonly string? _searchTerm;
        private readonly string? _sortColumn;
        private readonly string? _sortOrder;
        private readonly int _page;
        private readonly int _pageSize;

        public GetAllCategories(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize)
        {
            _searchTerm = searchTerm;
            _sortColumn = sortColumn;
            _sortOrder = sortOrder;
            _page = page;
            _pageSize = pageSize;
        }

        public string? SearchTerm => _searchTerm;

        public string? SortColumn => _sortColumn;

        public string? SortOrder => _sortOrder;

        public int Page => _page;

        public int PageSize => _pageSize;
    }
}
