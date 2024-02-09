namespace Application.Abstractions
{
    using Domain.Entities;
    public interface ICategoryRepository
    {
        Task<PagedList<Category>> GetAll(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize);

        Task<Category> GetCategoryById(int id);

        Task<Category> AddCategory(Category model);

        Task<Category> UpdateCategory(int id, string name);

        Task DeleteCategory(int id);
    }
}
