using Microsoft.AspNetCore.Mvc;
using PetStore.Model.Login;
using Service.Login;

namespace PetStore.Api.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loginService.Authencate(request);

            if (string.IsNullOrEmpty(result.Data))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}