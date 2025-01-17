using Core.Application.Menu.Commands.CreateMenuItem;
using Core.Application.Menu.Commands.CreateMenuSection;
using Core.Contracts.Menu.Request;
using Core.Contracts.Menu.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("restaurants/{restaurantId:guid}/menu")]
    public class MenuController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public MenuController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("sections")]
        public async Task<IActionResult> Create(
            Guid restaurantId,
            CreateMenuSectionRequest request)
        {
            var command = _mapper.Map<CreateMenuSectionCommand>((restaurantId, request));

            var section = await _mediator.Send(command);

            return section.Match(
                s => Ok(_mapper.Map<MenuSectionResponse>(s)),
                e => Problem(e));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("sections/{sectionId:guid}/items")]
        public async Task<IActionResult> Create(
            Guid restaurantId,
            Guid sectionId,
            CreateMenuItemRequest request)
        {
            var command = _mapper.Map<CreateMenuItemCommand>((restaurantId, sectionId, request));

            var item = await _mediator.Send(command);

            return item.Match(
                i => Ok(_mapper.Map<MenuItemResponse>(i)),
                e => Problem(e));
        }
    }
}