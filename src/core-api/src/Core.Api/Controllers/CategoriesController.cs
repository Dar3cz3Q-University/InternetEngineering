using Core.Application.Categories.Command.CreateCategory;
using Core.Application.Categories.Command.DeleteCategory;
using Core.Application.Categories.Query.GetCategories;
using Core.Contracts.Category.Request;
using Core.Contracts.Category.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("categories")]
    public class CategoriesController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CategoriesController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCategoriesQuery();

            var categories = await _mediator.Send(query);

            return categories.Match(
                c => Ok(c.ConvertAll(r => _mapper.Map<CategoryResponse>(r))),
                e => Problem(e));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryRequest request)
        {
            var command = _mapper.Map<CreateCategoryCommand>(request);

            var createCategory = await _mediator.Send(command);

            return createCategory.Match(
                c => Ok(_mapper.Map<CategoryResponse>(c)),
                e => Problem(e));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = _mapper.Map<DeleteCategoryCommand>(id);

            var response = await _mediator.Send(command);

            return response.Match(
                _ => NoContent(),
                e => Problem(e));
        }
    }
}