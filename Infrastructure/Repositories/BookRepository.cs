using Application;
using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<PagedList<Book>> GetAll(string? searchTerm,
                                                  string? sortColumn,
                                                  string? sortOrder,
                                                  int page,
                                                  int pageSize)
        {
            IQueryable<Book> bookQuery = _dbContext.Book;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                bookQuery = bookQuery.Where(c => c.Title.Contains(searchTerm) || c.Description.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                bookQuery = bookQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                bookQuery = bookQuery.OrderBy(GetSortProperty(sortColumn));
            }

            var books = await PagedList<Book>.CreateAsync(bookQuery, page, pageSize);


            return books;
        }

        public async Task<PagedList<Book>> GetAllByCategoryId(int categoryId,
                                                          string? searchTerm,
                                                          string? sortColumn,
                                                          string? sortOrder,
                                                          int page,
                                                          int pageSize)
        {
            var category = await _dbContext.Category.FindAsync(categoryId);

            if (category is null)
                throw new Exception($"Could not find book category. Category ID: {categoryId}");

            IQueryable<Book> bookQuery = _dbContext.Book
                .Where(b => b.CategoryId == categoryId)
                .Include(b => b.Category);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                bookQuery = bookQuery.Where(c => c.Title.Contains(searchTerm) || c.Description.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                bookQuery = bookQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                bookQuery = bookQuery.OrderBy(GetSortProperty(sortColumn));
            }

            var books = await PagedList<Book>.CreateAsync(bookQuery, page, pageSize);


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

        private static Expression<Func<Book, object>> GetSortProperty(string? sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "title" => book => book.Title,
                "publishDate" => book => book.PublicDateUtc,
                _ => book => book.ID
            };
        }
    }
}
