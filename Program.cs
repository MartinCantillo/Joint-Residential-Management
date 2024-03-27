
using System.Text;
using DataDataContext.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.Usern;
using RepositoriesIAuthenticationUser.IAuthenticationUser;
using RepositoriesIResidente.IResidente;
using RepositoriesIUser;
using ServicesAuthenticationUser.AuthenticationUser;
using ServicesResidenteS.SResidente;

var builder = WebApplication.CreateBuilder(args);

//Agego el servicio de autenticacion

builder.Services.AddScoped<IAuthenticationUser, AuthenticationUser>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IResidente, SResidente>();
//Config JWT
//Primero busco la secretkey
builder.Configuration.AddJsonFile("appsettings.json");
//Obtengo la secretkey
string? secretkey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
//codifico la secretkey
var keyBytes = Encoding.UTF8.GetBytes(secretkey ?? "");
//Configuro el sistema de jwt en el contenedor
builder.Services.AddAuthentication(config =>
{
    //empiezo a configurarlo
    //configuro jwt como  el esquema  predeterminado
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //configuro el jwt como esquema de desafio predeterminado
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    //desaactivar la validacion de https para simplificar el desarrollo
    config.RequireHttpsMetadata = false;
    //Habilitar la persistencia del token, osea que lo guarda enla memoria local
    config.SaveToken = true;
    //configurar la validacion del token
    config.TokenValidationParameters = new TokenValidationParameters
    {
        //primero valido la firma del emisor
        ValidateIssuerSigningKey = true,
        //Establezco la clave de la firma del emisor
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        //validar el emisor del token
        ValidateIssuer = true,
        ValidIssuer="backend",
        //valido la audiencia , osea para que apis en especifico se va a usar el token 
        ValidateAudience = false,
        ValidateLifetime = true, // Opcional: Validar la vigencia del token
        ClockSkew = TimeSpan.Zero // Opcional: Sin margen de ajuste para el reloj
    }
;
});




// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Servicio de la conexion con la bd
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL("server=localhost;port=3306;database=bdtestb;user=root");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
