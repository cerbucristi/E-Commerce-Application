using ECommerce.Application.Features.Orders.Commands.CreateOrder;
using ECommerce.Application.Features.Wishlists.Commands.CreateWishlist;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Application.API.Controllers
{

    [Authorize(Roles = "Admin")]
    [EnableCors("Open")]
    public class OrderController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result.Order);
        }
    }
}
