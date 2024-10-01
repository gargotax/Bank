using Application.CreateUserComand;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>>CreateUser(CreateUserRequest request, [FromServices]ICreateUserComandHandler handler, CancellationToken cancellationToken)
        {
            CreateUserComand comand = new(request.Name);
            try
            {
                var userId = await handler.HandleAsync(comand, cancellationToken);
                return Created(string.Empty, userId);
            }
            catch (Exception)
            {
                return BadRequest();
            }           
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
