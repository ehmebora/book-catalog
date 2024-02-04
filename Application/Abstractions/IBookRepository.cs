namespace Application.Abstractions
{
    using Domain.Entities;
    public interface IBookRepository
    {
        Task<IList<Book>> GetAll();
        Task<IList<Book>> GetAllByCategoryId(int categoryId);
        Task<Book> GetBookById(int id);
        Task<Book> AddBook(Book model);
        Task<Book> UpdateBook(int id, Book model);
        Task DeleteBook(int id);
    }
}
