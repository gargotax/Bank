using Application.AccountComands;
using BaknApi.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaknApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost("{userId}")]
        public async Task<ActionResult<Guid>> CreateAccount([FromRoute] Guid userId, CreateAccountRequest request, [FromServices] ICreateAccountComandHandler handler, CancellationToken cancellationToken)
        {
            if (request.AccountType == Account.AccountType.SavingAccount)
            {
                CreateAccountComand comand = new(userId, request.MaxDepositAmountAllowed, request.AccountType);
                Guid accountId = await handler.HandleAsync(comand, cancellationToken);
                return Created(string.Empty, accountId);
            }
            else
            {
                CreateAccountComand comand = new(userId, balance: request.Balance, overdraft: request.Overdraft, accountType: request.AccountType);
                Guid accountId = await handler.HandleAsync(comand, cancellationToken);
                return Created(string.Empty, accountId);
            }
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
