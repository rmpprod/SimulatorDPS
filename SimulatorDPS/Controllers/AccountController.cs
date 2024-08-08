using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SimulatorDPS.Models;
using SimulatorDPS.Services;

namespace SimulatorDPS.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private UserService _userService;
        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IResult GetUser()
        {
            var currentUser = HttpContext.User.Identity.Name;
            var userModel = _userService.GetUserByLogin(currentUser);
            return Results.Ok(userModel);
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public IResult CreateUser([FromBody] UserDTO userDTO)
        {
            var newUser = _userService.CreateUser(userDTO.Login, userDTO.Password);
            return Results.Ok(newUser);
        }

        [HttpPatch]
        public IResult UpdateUser([FromBody] UserModel userModel)
        {
            var user = _userService.UpdateUser(userModel.Id, userModel.UserName);
            return Results.Ok(user);
        }

        [HttpDelete]
        public IResult DeleteUser([FromBody] UserModel userModel)
        {
            var deleteUser = _userService.DeleteUser(userModel.Id, userModel.UserName);
            return Results.Ok(deleteUser);
        }
        [AllowAnonymous]
        [HttpPost("token")]
        public IResult GetToken()
        {
            var userData = _userService.GetUserLoginPassBasicAuth(Request);
            var identity = _userService.GetIdentity(userData.Login, userData.Password);
            var token = _userService.CreateJWToken(identity);
            return Results.Ok(token);
        }
    }
}