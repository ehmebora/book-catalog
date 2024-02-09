using Application;
using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookCatalogDbContext _dbContext;

        public CategoryRepository(BookCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> AddCategory(Category model)
        {
            _dbContext.Category.Add(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _dbContext.Category.FindAsync(id);

            if (category is null)
                throw new Exception($"Could not find book category. Category ID: {id}");

            _dbContext.Category.Remove(category);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<PagedList<Category>> GetAll(string? searchTerm,
                                                  string? sortColumn,
                                                  string? sortOrder,
                                                  int page, 
                                                  int pageSize)
        {
            IQueryable<Category> categoryQuery = _dbContext.Category;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                categoryQuery = categoryQuery.Where(c => c.Name.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                categoryQuery = categoryQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                categoryQuery = categoryQuery.OrderBy(GetSortProperty(sortColumn)); 
            }

            var categories = await PagedList<Category>.CreateAsync(categoryQuery, page, pageSize);
              

            return categories;
        }

        private static Expression<Func<Category, object>> GetSortProperty(string? sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => category => category.Name,
                _ => category => category.ID
            };
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _dbContext.Category.FindAsync(id);

            if (category is null)
                throw new Exception($"Could not find book category. Category ID: {id}");

            return category;
        }

        public async Task<Category> UpdateCategory(int id, string name)
        {
            var category = await _dbContext.Category.FindAsync(id);

            if (category is null) 
                throw new Exception($"Could not find book category. Category ID: {id}");

            category.Name = name;

            _dbContext.Set<Category>();
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
