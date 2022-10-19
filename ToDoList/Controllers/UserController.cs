

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Controllers;
using ToDoList.Core.Managers.Interfaces;
using ToDoList.ViewModels.ViewModels;

namespace ToDoList.Controllers
{
     [ApiController]
     [Authorize]
    public class UserController : BaseApi
    {
        private IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager; 
        }


        [HttpPost]
        [Route("api/user/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest userLogin)
        {
            var res = _userManager.Login(userLogin);
            return Ok(res);
        }

        [HttpPost]
        [Route("api/user/signUp")]
        [AllowAnonymous]
        public IActionResult SignUp(UserRegistration userRegistration)
        {
            var res = _userManager.SignUp(userRegistration);
            return Ok(res);
        }

        [HttpPut]
        [Route("api/user/updateUser")]
        public IActionResult UpdateUser(UserModel userModel)
        {
            var res = _userManager.UpdateInfoUser(TokenUser, userModel);
            return Ok(res);
        }

        [HttpDelete]
        [Route("api/user/delete")]
        public IActionResult Delete(int id)
        {
            _userManager.Delete(TokenUser, id);
            return Ok();
        }
    }
}
