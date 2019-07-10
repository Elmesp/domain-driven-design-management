namespace Emerging.Account.WebApi.Controllers
{
    using System.Threading.Tasks;
    using Emerging.Account.DomainModel.Entities;
    using Emerging.Account.DomainModel.Services;
    using Emerging.Account.WebApi.Models;
    using Emerging.Account.WebApi.Services.Auth0;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService accountService;
        private readonly Auth0Service auth0Service;

        public AccountController(
            AccountService accountService,
            Auth0Service auth0Service)
        {
            this.accountService = accountService;
            this.auth0Service = auth0Service;
        }

        [HttpHead("{id}")]
        [HttpGet("{id}", Name = "GetAccount")]
        public IActionResult Get(string id)
        {
            var account = accountService.GetById(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AccountPostRequestBody model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            ValidateEmailAndPhoneInUse(model);

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var account = await RegisterAccount(model);
            var responseBody = account.ToAccountPostResponseBody();

            return CreatedAtRoute("GetAccount", new { id = responseBody.Id }, responseBody);
        }

        private void ValidateEmailAndPhoneInUse(AccountPostRequestBody model)
        {
            if (accountService.IsEmailInUse(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "This email is already registered.");
            }

            if (accountService.IsPhoneInUse(model.Phone))
            {
                ModelState.AddModelError(nameof(model.Phone), "This phone is already registered.");
            }
        }

        private async Task<Account> RegisterAccount(AccountPostRequestBody model)
        {
            var user_id = await auth0Service.SignUpAndGetId(model.Email, model.Password);
            var account = model.ToAccount(user_id);

            accountService.Register(account);

            return account;
        }
    }
}
