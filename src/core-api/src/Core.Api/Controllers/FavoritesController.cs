using Core.Application.Favorites.Commands.AddFavorite;
using Core.Application.Favorites.Commands.RemoveFavorite;
using Core.Application.Favorites.Queries.GetFavorites;
using Core.Contracts.Favorite.Request;
using Core.Contracts.Favorite.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("favorites")]
    public class FavoritesController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public FavoritesController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            var query = new GetFavoritesQuery();

            var result = await _mediator.Send(query);

            return result.Match(
                r => Ok(new FavoritesResponse(r)),
                e => Problem(e)
            );
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(AddFavoriteRequest request)
        {
            var command = _mapper.Map<AddFavoriteCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                r => Created(),
                e => Problem(e)
            );
        }

        [HttpDelete("{restaurantId:guid}")]
        public async Task<IActionResult> RemoveFavorite(Guid restaurantId)
        {
            var command = new RemoveFavoriteCommand(restaurantId);

            var result = await _mediator.Send(command);

            return result.Match(
                r => NoContent(),
                e => Problem(e)
            );
        }
    }
}