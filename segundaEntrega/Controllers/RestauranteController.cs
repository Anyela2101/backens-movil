using System.Runtime.ExceptionServices;
using System.ComponentModel;
using System.IO.Pipes;
using System.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using segundaEntrega.Models;
using Datos;
using Microsoft.AspNetCore.SignalR;
using segundaEntrega.Hubs;
using Microsoft.AspNetCore.Http;

namespace segundaEntrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly RestauranteService _restauranteService;
        private readonly IHubContext<SignalHub> _hubContext;
        public RestauranteController(PersonaContext context, IHubContext<SignalHub> hubContext)
        {

            _restauranteService = new RestauranteService(context);
            _hubContext = hubContext;
        }

        // GET: api/Restaurante
        [HttpGet()]
        public IEnumerable<RestauranteViewModel> Gets()
        {
            /* var restaurantes = _restauranteService.ConsultarTodos().Select(p=> new RestauranteViewModel(p));
            return restaurantes; */
            var restaurantes = _restauranteService.ConsultarTodos().Select(p => new RestauranteViewModel(p));
            return restaurantes;
        }

        // POST: api/Restaurante
        [HttpPost]
        public async Task<ActionResult<RestauranteViewModel>> Post(RestauranteInputModel restauranteInput)
        {

            Restaurante restaurante = MapearRestaurante(restauranteInput);
            var response = _restauranteService.Guardar(restaurante);

            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            await _hubContext.Clients.All.SendAsync("RegistrarRestaurante", new RestauranteViewModel(response.Restaurante));
            return Ok(response.Restaurante);
        }
        [HttpGet("{nombre}")]
        public ActionResult<RestauranteViewModel> Get(string nombre)
        {
            var response = _restauranteService.Buscar(nombre);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Restaurante);
        }

        [HttpPut]
        public ActionResult<RestauranteViewModel> EditarRestaurante(RestauranteInputModel restauranteInput)
        {
            Restaurante restaurante = MapearRestaurante(restauranteInput);
            var response = _restauranteService.EditarRestaurante(restaurante);
            if (response.Error)
            {
                ModelState.AddModelError("Error al editar el Restaurante", response.Mensaje);
                var problemas = new ValidationProblemDetails(ModelState);
                if (response.Estado == "NoExiste")
                {
                    problemas.Status = StatusCodes.Status404NotFound;
                }

                if (response.Estado == "Error")
                {
                    problemas.Status = StatusCodes.Status500InternalServerError;
                }

                return BadRequest(problemas);
            }
            return Ok(response.Restaurante);
        }


        [HttpDelete("{nit}")]
        public ActionResult<RestauranteViewModel> EliminarRestaurante(string nit)
        {
            var response = _restauranteService.EliminarRestaurante(nit);
            if (response.Error)
            {
                ModelState.AddModelError("Error al eliminar el Restaurante", response.Mensaje);
                var problemas = new ValidationProblemDetails(ModelState);
                if (response.Estado == "NoExiste")
                {
                    problemas.Status = StatusCodes.Status404NotFound;
                }

                if (response.Estado == "Error")
                {
                    problemas.Status = StatusCodes.Status500InternalServerError;
                }

                return BadRequest(problemas);
            }
            return Ok(response.Restaurante);
        }

        private Restaurante MapearRestaurante(RestauranteInputModel restauranteInput)
        {
            var restaurante = new Restaurante();
            restaurante.NIT = restauranteInput.Nit;
            restaurante.Nombre = restauranteInput.Nombre;
            restaurante.Propietario = restauranteInput.Propietario;
            restaurante.Direccion = restauranteInput.Direccion;
            restaurante.CantidadPersonal = restauranteInput.CantidadPersonal;
            restaurante.Telefono = restauranteInput.Telefono;
            restaurante.Email = restauranteInput.Email;
            restaurante.Sedes = restauranteInput.Sedes;
            restaurante.AñoFuncionamiento = restauranteInput.AñoFuncionamiento;
            restaurante.Especialidad = restauranteInput.Especialidad;
            restaurante.Personals = new List<Persona>();
            return restaurante;
        }


    }
}