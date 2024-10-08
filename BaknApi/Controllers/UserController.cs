using Application.UserComands.CreateUserComand;
using Application.UserComands.DeleteUserComand;
using Application.UserComands.GetUserComand;
using Application.UserComands.UpdateUserComand;
using BaknApi.Dto;
using BaknApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaknApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [ProducesResponseType<UserDto>(StatusCodes.Status200OK)]
        [ProducesResponseType<UserDto>(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUser([FromRoute] Guid id, [FromServices]IGetUserComandHandler handler, CancellationToken cancellationToken)
        {
            GetUserComand comand = new(id);
            try
            {
                var user = await handler.HandleAsync(comand, cancellationToken);
                UserDto userDto = new(user.IdUser, user.Name, user.NhsNumber);
                return Ok(userDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateUser(CreateUserRequest request, [FromServices] ICreateUserComandHandler handler, CancellationToken cancellationToken)
        {
            CreateUserComand comand = new(request.Name, request.NhsNumber);
            try
            {
                Guid userId = await handler.HandleAsync(comand, cancellationToken);
                return Created(string.Empty, userId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest request, [FromServices]IUpdateUserComandHandler handler, CancellationToken cancellationToken)
        {
            UpdateUserComand comand = new(id, request.Name);
            try
            {
                await handler.HandleAsync(comand, cancellationToken);
                return Ok();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteUser([FromRoute] Guid id, [FromServices]IDeleteUserComandHandler handler, CancellationToken cancellationToken)
        {
            DeleteUserComand comand = new(id);
            await handler.HandleAsync(comand, cancellationToken);
            return NoContent();
        }
    }
}
