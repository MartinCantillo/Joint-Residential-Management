using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataDataContext.DataContext;

using ServicesAuthenticationUser.AuthenticationUser;
using RepositoriesIAuthenticationUser.IAuthenticationUser;
using System.Data.Entity;
using ModelsUser.Usern;
using RepositoriesIUser;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ControllerAuthenticateUser.AuthenticateUser
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateUserController : ControllerBase
    {
       
        private readonly IAuthenticationUser _authenticationUser;
        private readonly IUser _IUser;
        public AuthenticateUserController(IAuthenticationUser authenticationUser,  IUser _IUser)
        {
            _authenticationUser = authenticationUser;
           
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
        public IActionResult Validate([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    //Valido las credencales del usuario
                    var UserValidated = this._authenticationUser.ValidateUser(user);
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

