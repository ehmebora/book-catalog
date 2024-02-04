namespace Application.Abstractions
{
    using Domain.Entities;
    public interface ICategoryRepository
    {
        Task<IList<Category>> GetAll();

        Task<Category> GetCategoryById(int id);

        Task<Category> AddCategory(Category model);

        Task<Category> UpdateCategory(int id, string name);

        Task DeleteCategory(int id);
    }
}
