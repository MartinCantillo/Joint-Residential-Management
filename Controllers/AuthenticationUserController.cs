using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModelsUser.User;
using ServicesAuthenticationUser.AuthenticationUser;

namespace ControllerAuthenticateUser.AuthenticateUser
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthenticateUserController : ControllerBase
    {
        private readonly AuthenticationUser? _AuthenticationUser;
        public AuthenticateUserController(AuthenticationUser _AuthenticationUser)
        {
            this._AuthenticationUser = _AuthenticationUser;
           
        }

        [HttpPost("/user")]
        public IActionResult validate([FromBody] User user ){
            if(!ModelState.IsValid){
                return  BadRequest();
            }else{
                //me falta crear el repositorio y servicios de user;
             //   this._AuthenticationUser.GenerateToken(user.Id_User,user.Username,user.Roles.);
            }

        }
    }


}