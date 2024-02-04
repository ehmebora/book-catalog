using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookCatalogDbContext _dbContext;

        public BookRepository(BookCatalogDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<Book> AddBook(Book model)
        {

            var category = await _dbContext.Category.FindAsync(model.CategoryId);

            if (category is null)
                throw new Exception($"Unable to create book record. Could not find book category ID: {model.CategoryId}");


            _dbContext.Book.Add(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task DeleteBook(int id)
        {
            var book = await _dbContext.Book.FindAsync(id);

            if (book is null)
                throw new Exception($"Could not find book. ID: {id}");


            _dbContext.Book.Remove(book);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Book>> GetAll()
        {
            return await _dbContext.Book.ToListAsync();
        }

        public async Task<IList<Book>> GetAllByCategoryId(int categoryId)
        {
            var category = await _dbContext.Category.FindAsync(categoryId);

            if (category is null)
                throw new Exception($"Could not find book category. Category ID: {categoryId}");

            var books = await _dbContext.Book
                        .Where(b => b.CategoryId == categoryId)
                        .Include(b => b.Category)
                        .ToListAsync();

            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _dbContext.Book.FindAsync(id);

            if (book is null)
                throw new Exception($"Could not find book. ID: {id}");

            return book;
        }

        public async Task<Book> UpdateBook(int id, Book model)
        {

            var book = await _dbContext.Book.FindAsync(id);

            if (book is null)
                throw new Exception("Could not find book");


            var category = await _dbContext.Category.FindAsync(model.CategoryId);

            if (category is null)
                throw new Exception($"Unable to update book record. Could not find book category ID: {model.CategoryId}");



            book.Title = model.Title;
            book.Description = model.Description;
            book.PublicDateUtc  = model.PublicDateUtc;
            book.CategoryId = model.CategoryId;

            _dbContext.Set<Book>();
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return book;
        }
    }
}
