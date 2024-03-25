using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RepositoriesIAuthenticationUser.IAuthenticationUser;

namespace ServicesAuthenticationUser.AuthenticationUser
{
    public class AuthenticationUser : IAuthenticationUser
    {
        //Creacion de la llave secreta
        private readonly string? secretkey;
        //Inyeccion de dependencia IConfiguration
        public AuthenticationUser(IConfiguration config)
        {
            //Busco la secretKey donde la almacene , en mi appsettings.json
            this.secretkey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        public string GenerateToken(int id, string nombre, ICollection<string> roles)
        {
            // Verifica si la clave secreta está configurada correctamente
            if (string.IsNullOrEmpty(secretkey))
            {
                // Lanza una excepción si la clave secreta no está configurada
                throw new InvalidOperationException("La clave secreta no está configurada correctamente.");
            }

            // Verifica si los campos requeridos están vacíos
            if (id == 0 || string.IsNullOrEmpty(nombre) || roles == null || !roles.Any())
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
            foreach (var rol in roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, rol));
            }
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




        public bool ValidateToken(string token)
        {
            // Verifica si la clave secreta está configurada correctamente
            if (string.IsNullOrEmpty(secretkey))
            {
                // Lanza una excepción si la clave secreta no está configurada
                throw new InvalidOperationException("La clave secreta no está configurada correctamente.");
            }

            // Creo el objeto para validar el token
            var tokenHandler = new JwtSecurityTokenHandler();

            // Convierte la clave secreta a bytes utilizando ASCII
            var keyBytes = Encoding.ASCII.GetBytes(secretkey);

            // Configura los parámetros de validación del token
            var tokenValidationParameters = new TokenValidationParameters
            {
                // Indica si se debe validar la clave de firma del emisor del token
                ValidateIssuerSigningKey = true,

                // Especifica la clave de firma utilizada para validar el token
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes),

                // Indica si se debe validar el emisor del token
                ValidateIssuer = false,

                // Indica si se debe validar el receptor del token (audience)
                ValidateAudience = false,

                // Define el margen de tiempo permitido para la diferencia entre la hora actual y la hora de expiración del token
                // Si la diferencia es menor o igual a este margen, el token se considera válido
                // Al establecerlo en TimeSpan.Zero, se espera que el token esté exactamente en la hora de expiración para considerarse válido
                ClockSkew = TimeSpan.Zero
            };

            // Valida el token utilizando los parámetros de validación especificados
            tokenHandler.ValidateToken(token, tokenValidationParameters, out var ValidateToken);

            // Retorna true si ValidateToken no es nulo, indicando que el token es válido; de lo contrario, retorna false
            return ValidateToken != null;
        }

    }
}