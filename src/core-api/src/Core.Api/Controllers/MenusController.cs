using Core.Application.Menus.Commands.CreateMenu;
using Core.Contracts.Menu.Request;
using Core.Contracts.Menu.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("menus")]
    public class MenusController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public MenusController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuRequest request)
        {
            var command = _mapper.Map<CreateMenuCommand>(request);

            var createMenu = await _mediator.Send(command);

            return createMenu.Match(
                m => Ok(_mapper.Map<MenuResponse>(m)),
                e => Problem(e));
        }

        [HttpPut]
        public async Task<IActionResult> Edit()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }
    }
}