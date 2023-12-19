using ECommerce.Application.Features.Categories.Commands.UpdateCategory;
using ECommerce.Application.Features.Manufacturers.Commands.CreateManufacturer;
using ECommerce.Application.Features.Manufacturers.Commands.DeleteManufacturer;
using ECommerce.Application.Features.Manufacturers.Commands.UpdateManufacturer;
using ECommerce.Application.Features.Manufacturers.Queries.GetAll;
using ECommerce.Application.Features.Manufacturers.Queries.GetById;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Application.API.Controllers
{
    [EnableCors("Open")]
    [Authorize(Roles = "Admin")]
    public class ManufacturersController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateManufacturerCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllManufacturersQuery());
            return Ok(result.Manufacturers);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdManufacturerQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteManufacturerCommand = new DeleteManufacturerCommand() { ManufacturerId = id };
            await Mediator.Send(deleteManufacturerCommand);
            return NoContent();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(Guid id, UpdateManufacturerCommand command)
        {
            if (id != command.ManufacturerId)
            {
                return BadRequest("ID mismatch between route parameter and request body.");
            }

            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return NoContent();
        }
    }
}
