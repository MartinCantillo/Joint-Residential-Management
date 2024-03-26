using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataDataContext.DataContext;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using ModelsUser.Usern;
using RepositoriesIAuthenticationUser.IAuthenticationUser;
using ZstdSharp;

namespace ServicesAuthenticationUser.AuthenticationUser
{
    public class AuthenticationUser : IAuthenticationUser
    {

        //Inyeccion de dependencia IConfiguration
        private readonly IConfiguration config;
        private readonly DataContext _DataContext;
        public AuthenticationUser(IConfiguration config, DataContext DbContext)
        {
            this.config = config;
            this._DataContext = DbContext;

        }

        public string GenerateToken(int id, string nombre, string roles)
        {
            //Busco la secretKey donde la almacene , en mi appsettings.json
            var secretkey = this.config.GetSection("settings").GetSection("secretkey").ToString();
            // Verifica si la clave secreta está configurada correctamente
            if (string.IsNullOrEmpty(secretkey))
            {

                // Lanza una excepción si la clave secreta no está configurada
                throw new InvalidOperationException("La clave secreta no está configurada correctamente.");
            }

            // Verifica si los campos requeridos están vacíos
            if (id == 0 || string.IsNullOrEmpty(nombre) || roles == null)
            {
                // Lanza una excepción si los campos requeridos están vacíos
                throw new ArgumentException("Los campos requeridos no pueden estar vacíos.");
            }

            // Crea un manejador de tokens JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            // Convierte la clave secreta a bytes utilizando ASCII
            var keyBytes = Encoding.ASCII.GetBytes(secretkey);

            // Crea un conjunto de claims para el usuario autenticado
            var claims = new ClaimsIdentity();
            // Agrega los roles como claims al conjunto de claims
            claims.AddClaim(new Claim(ClaimTypes.Role, roles));

            // Agrega un claim para el ID del usuario
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
            // Agrega un claim para el nombre del usuario
            claims.AddClaim(new Claim(ClaimTypes.Name, nombre));

            // Configura el objeto del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Especifica los claims que van en el token
                Subject = claims,
                // Especifica la fecha de expiración del token
                Expires = DateTime.UtcNow.AddHours(1), // Token expira en 1 hora
                                                       // Especifica la firma del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            // Crea el token JWT utilizando el tokenHandler y el tokenDescriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // Retorna el token JWT como una cadena
            return tokenHandler.WriteToken(token);
        }

        public User ValidateUser(User user)
        {

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {

                throw new Exception("Datos vacios");

            }
            else
            {
                // Validar las credenciales del usuario
                User validatedUser = _DataContext.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
                if (validatedUser != null)
                {
                    // Consultar el usuario completo con sus roles
                    var validatedUser2 = _DataContext.Users.FirstOrDefault(u => u.Id_User == validatedUser.Id_User);

                    if (validatedUser2 != null && validatedUser2.Roles != null)
                    {

                        return validatedUser2;
                    }
                    else
                    {

                        throw new Exception($"El usuario no tiene roles asignados");
                    }
                }
                else
                {
                    throw new Exception("Usuario no encontrado");
                }




            }
        }
    }
}