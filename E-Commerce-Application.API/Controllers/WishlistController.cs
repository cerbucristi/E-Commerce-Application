using E_Commerce_Application.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using ECommerce.Application.Features.Wishlists.Commands.CreateWishlist;
using ECommerce.Application.Features.Events.Commands.DeleteWishlist;

namespace ECommerce.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [EnableCors("Open")]
    public class WishlistController : ApiControllerBase
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateWishlistCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result.Wishlist);
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(Guid productId)
        {
            var deleteWishlistCommand = new DeleteWishlistCommand { ProductId = productId };
            var result = await Mediator.Send(deleteWishlistCommand);

            if (!result.Success)
            {
                return NotFound(result.ValidationsErrors);
            }

            return NoContent();
        }
    }
}
