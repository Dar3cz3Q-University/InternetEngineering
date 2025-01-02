using Core.Application.Menus.Commands.CreateMenu;
using Core.Application.Menus.Commands.DeleteMenu;
using Core.Application.Menus.Commands.UpdateMenu;
using Core.Application.Menus.Queries.GetMenu;
using Core.Application.Menus.Queries.GetMenus;
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
            var query = new GetMenusQuery();

            var menus = await _mediator.Send(query);

            return menus.Match(
                m => Ok(m.ConvertAll(m => _mapper.Map<MenuResponse>(m))),
                e => Problem(e));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = _mapper.Map<GetMenuQuery>(id);

            var menu = await _mediator.Send(query);

            return menu.Match(
                m => Ok(_mapper.Map<MenuResponse>(m)),
                e => Problem(e));
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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateMenuRequest request)
        {
            var command = _mapper.Map<UpdateMenuCommand>((id, request));

            var updateMenu = await _mediator.Send(command);

            return updateMenu.Match(
                m => Ok(_mapper.Map<MenuResponse>(m)),
                e => Problem(e));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = _mapper.Map<DeleteMenuCommand>(id);

            var response = await _mediator.Send(command);

            return response.Match(
                _ => NoContent(),
                e => Problem(e));
        }
    }
}