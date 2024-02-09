namespace Application.Abstractions
{
    using Domain.Entities;
    public interface IBookRepository
    {
        Task<PagedList<Book>> GetAll(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize);
        Task<PagedList<Book>> GetAllByCategoryId(int categoryId, string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize);
        Task<Book> GetBookById(int id);
        Task<Book> AddBook(Book model);
        Task<Book> UpdateBook(int id, Book model);
        Task DeleteBook(int id);
    }
}
