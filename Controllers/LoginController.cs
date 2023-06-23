using ApiPolizaSeguros.Models;
using ApiPolizaSeguros.Services;
using ApiPolizaSeguros.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPolizaSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public ActionResult Token(UsuarioLogin credenciales)
        {
           
            if (this.authService.ValidateLogin(credenciales.Usuario, credenciales.Password))
            {
                var fechaActual = DateTime.UtcNow;
                var validez = TimeSpan.FromHours(5);
                var fechaExpiracion = fechaActual.Add(validez);

                var token = authService.GenerateToken(fechaActual, credenciales.Usuario, validez);
                return Ok(new
                {
                    Token = token,
                    ExpireAt = fechaExpiracion
                });
            }
            return StatusCode(401);
        }
    }
}
