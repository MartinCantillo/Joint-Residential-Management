using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsUser.Usern;
using RepositoriesIUser;

namespace ControllersUsers.UsersController
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly IUser _IUser;

        public UsersController(IUser _IUser)
        {
            this._IUser = _IUser;
        }


        [HttpPost("saveUsser")]
        public IActionResult SaveUsser([FromBody] User user)
        {
            try
            {

                if (user.Username == "" || user.Password == "" || user.Roles == "" )
                {
                    return BadRequest();

                }
                else
                {
                    this._IUser.SaveUser(user);
                    return Ok("Usuario registrado con exito");
                }


            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        public ActionResult<ICollection<User>> GetAllUsers()
        {
            return Ok(this._IUser.GetAll());
        }


    }
}