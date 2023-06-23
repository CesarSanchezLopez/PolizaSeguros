using ApiPolizaSeguros.Models;
using ApiPolizaSeguros.Services;
using ApiPolizaSeguros.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<PolizaSettings>
            (builder.Configuration.GetSection(nameof(PolizaSettings)));

builder.Services.AddSingleton<IPolizaSettings>
     (d => d.GetRequiredService<IOptions<PolizaSettings>>().Value);

builder.Services.AddSingleton<PolizaService>();

builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));//inyectando servicio
              



builder.Services.AddControllers();

//JWT

builder.Services.AddAuthorization(options =>
        options.DefaultPolicy =
        new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build()
    );
//estos valores los obtenemos de nuestro appsettings
var issuer = builder.Configuration["AuthenticationSettings:Issuer"];
var audience = builder.Configuration["AuthenticationSettings:Audience"];
var signinKey = builder.Configuration["AuthenticationSettings:SigningKey"];
//autenticacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Audience = audience;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signinKey))
        };
    }
  );

// END JWT

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlizaSeguros v1"));
    //app.UseSwaggerUI();
}
//Configurando la aplicación para JWT
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
