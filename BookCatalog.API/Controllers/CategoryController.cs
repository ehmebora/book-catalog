using Application.Category.Commands;
using Application.Category.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IList<Category>>> GetAll(IMediator mediator,
            string? searchTerm,
            string? sortColumn,
            string? sortOrder,
            int page = 1,
            int pageSize = 5)
        {
            var query = new GetAllCategories(searchTerm, sortColumn, sortOrder, page, pageSize);
            var categories = await mediator.Send(query);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(IMediator mediator, int id)
        {
            var category = await mediator.Send(new GetCategoryById() { Id = id });
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(IMediator mediator, [FromBody] string name)
        {
            var category = await mediator.Send(new CreateCategory() { Name = name });
            return Ok(category);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(IMediator mediator, int id, [FromBody] string name)
        {
            var category = await mediator.Send(new UpdateCategory() { Id = id, Name = name});
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCategory(IMediator mediator, int id)
        {
            await mediator.Send(new DeleteCategory() { Id = id });
        }
    }
}
