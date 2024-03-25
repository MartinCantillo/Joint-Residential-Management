using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataDataContext.DataContext;
using ModelsUser.User;
using ServicesAuthenticationUser.AuthenticationUser;
using RepositoriesIAuthenticationUser.IAuthenticationUser;
using System.Data.Entity;

namespace ControllerAuthenticateUser.AuthenticateUser
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateUserController : ControllerBase
    {
        private readonly DataContext _DataContext;
        private readonly IAuthenticationUser _authenticationUser;

        public AuthenticateUserController(IAuthenticationUser authenticationUser, DataContext dataContext)
        {
            _authenticationUser = authenticationUser;
            _DataContext = dataContext;
        }

        [HttpPost("/user")]
        public IActionResult Validate([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                Console.WriteLine("Datos vacíos");
                return BadRequest("Datos vacíos");
            }

            // Validar las credenciales del usuario
            User validatedUser = _DataContext.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            if (validatedUser != null)
            {
                // Consultar el usuario completo con sus roles
                validatedUser = _DataContext.Users.FirstOrDefault(u => u.Id_User == validatedUser.Id_User);

                if (validatedUser != null && validatedUser.Roles != null)
                {

                    // Generar el token
                    string token = _authenticationUser.GenerateToken(validatedUser.Id_User, validatedUser.Username, validatedUser.Roles);
                    return Accepted(token);
                }
                else
                {

                    return BadRequest($"El usuario no tiene roles asignadosa");
                }
            }
            else
            {
                return NotFound("Usuario no encontrado");
            }
        }

    }
}

