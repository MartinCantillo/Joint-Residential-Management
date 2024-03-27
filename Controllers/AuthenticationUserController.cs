
using Microsoft.AspNetCore.Mvc;


using RepositoriesIAuthenticationUser.IAuthenticationUser;
using ModelsUser.Usern;
using RepositoriesIUser;


namespace ControllerAuthenticateUser.AuthenticateUser
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateUserController : ControllerBase
    {

        private readonly IAuthenticationUser _authenticationUser;
        private readonly IUser _IUser;
        public AuthenticateUserController(IAuthenticationUser authenticationUser, IUser _IUser)
        {
            this._authenticationUser = authenticationUser;

            this._IUser = _IUser;
        }

        [HttpPost("/saveUser")]
        public IActionResult SaveUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "El usuario proporcionado es nulo");
                }

                _IUser.SaveUser(user);

                return Ok("Usuario guardado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar usuario: {ex.Message}");
            }
        }

        [HttpPost("/userValidate")]
        //[fromBody]para deserializar los datos
        public IActionResult Validate(string user, string password)
        {
            try
            {
                if (user == "" || password == "")
                {
                    return BadRequest("Por favor ingrese los datos S");
                }
                else
                {
                    //Valido las credencales del usuario
                    var UserValidated = this._authenticationUser.ValidateUser(user, password);
                    if (UserValidated == null)
                    {
                        throw new Exception("Not found");
                    }
                    // Generar el token
                    string token = _authenticationUser.GenerateToken(UserValidated.Id_User, UserValidated.Username, UserValidated.Roles);
                    return Ok(token);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Manejo de la excepción y retorno de un error HTTP 500
            }
        }

    }
}

