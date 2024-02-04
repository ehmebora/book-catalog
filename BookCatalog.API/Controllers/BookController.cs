using Application.Book.Commands;
using Application.Book.Queries;
using Application.Category.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IList<Book>>> GetAll(IMediator mediator)
        {
            var books = await mediator.Send(new GetAllBooks() { });
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
        public async Task<ActionResult<Book>> GetByCategoryId(IMediator mediator, int id)
        {
            var request = new GetBooksByCategoryId() { CategoryId = id };
            var books = await mediator.Send(request);
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(IMediator mediator, [FromBody] BookDTO model)
        {
            var request = new CreateBook()
            {
                CategoryId = model.CategoryId,
                Title = model.Title,
                Description = model.Description,
                PublicDateUtc = model.PublicDateUtc
            };

            var book = await mediator.Send(request);
            return Ok(book);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(IMediator mediator, int id, [FromBody] BookDTO model)
        {
            var request = new UpdateBook()
            {
                Id = id,
                CategoryId = model.CategoryId,
                Title = model.Title,
                Description = model.Description,
                PublicDateUtc = model.PublicDateUtc
            };

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
