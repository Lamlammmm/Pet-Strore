using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Service;

namespace PetStore.Api.Controllers
{
    public class UserContactController : BaseController
    {
        private readonly IUserContactService _userContactService;

        public UserContactController(IUserContactService userContactService)
        {
            _userContactService = userContactService;
        }

        [HttpPost("Create-UserContact")]
        public async Task<IActionResult> Create(UserContact model)
        {
            var item = await _userContactService.Create(model);
            return Ok(item);
        }
    }
}