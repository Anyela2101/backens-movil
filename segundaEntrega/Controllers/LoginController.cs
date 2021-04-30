using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using segundaEntrega.Config;
using segundaEntrega.Models;
using segundaEntrega.Service;

namespace segundaEntrega.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController:ControllerBase
    {
        private JwtService _jwtService;
        private UsuarioService _userService;

        PersonaContext _context;
        public LoginController(PersonaContext context, IOptions<AppSetting> appSettings)
        {
            _context = context;
            var admin = _context.Usuarios.Find("admin");
            if (admin == null)
            {
                _context.Usuarios.Add(new Entidad.Usuario() { User = "admin", Password = "admin", Email = "admin@gmail.com", Token = "a1b2c3", FirstName = "Adminitrador", LastName = "", Tipo="Administrador"});
                var i = _context.SaveChanges();
            }
            _jwtService = new JwtService(appSettings);
            _userService = new UsuarioService(context);
        }
        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Login(UsuarioInputModel model)
        {
            var user = _userService.Validate(model.User, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("Acceso Denegado", "Username or password is incorrect");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            var response = _jwtService.GenerateToken(user);

            return Ok(response);
        }
    }
}