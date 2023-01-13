using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStore.Service;

namespace PetStore.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


    }
}
