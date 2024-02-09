using Application.Book.Commands;
using Application.Book.Queries;
using BookCatalog.API.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IList<Book>>> GetAll(IMediator mediator,
            string? searchTerm,
            string? sortColumn,
            string? sortOrder,
            int page = 1,
            int pageSize = 5)
        {
            var query = new GetAllBooks(searchTerm, sortColumn, sortOrder, page, pageSize);

            var books = await mediator.Send(query);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(IMediator mediator, int id)
        {
            var request = new GetBookById() { Id = id };
            var book = await mediator.Send(request);
            return Ok(book);
        }

        [HttpGet("Category/{id}")]
        public async Task<ActionResult<IList<Book>>> GetByCategoryId(IMediator mediator, 
            int id,
            string? searchTerm,
            string? sortColumn,
            string? sortOrder,
            int page = 1,
            int pageSize = 5)
        {
            var query = new GetBooksByCategoryId(searchTerm, sortColumn, sortOrder, page, pageSize) { CategoryId = id,  };

            var books = await mediator.Send(query);
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(IMediator mediator, [FromBody] BookDTO model)
        {

            var request = Mapper.Map<CreateBook>(model);
            //var request = new CreateBook()
            //{
            //    CategoryId = model.CategoryId,
            //    Title = model.Title,
            //    Description = model.Description,
            //    PublicDateUtc = model.PublicDateUtc
            //};

            var book = await mediator.Send(request);
            return Ok(book);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(IMediator mediator, int id, [FromBody] BookDTO model)
        {

            var request = Mapper.Map<UpdateBook>(model);
            request.Id = id;


            //var request = new UpdateBook()
            //{
            //    Id = id,
            //    CategoryId = model.CategoryId,
            //    Title = model.Title,
            //    Description = model.Description,
            //    PublicDateUtc = model.PublicDateUtc
            //};

            var book = await mediator.Send(request);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task DeleteBook(IMediator mediator, int id)
        {
            var request = new DeleteBook() { Id = id };
            await mediator.Send(request);
        }
    }
}
