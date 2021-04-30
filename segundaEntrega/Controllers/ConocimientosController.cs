using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using segundaEntrega.Models;
using Datos;
namespace segundaEntrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConocimientosController:ControllerBase
    {
        private readonly ConocimientosService _conocimientosService;
        public ConocimientosController(PersonaContext context){
    
            _conocimientosService = new ConocimientosService(context);
        }

        // GET: api/Persona
        [HttpGet()]
        public IEnumerable<ConocimientosViewModel> Gets(){
            var conocimientos = _conocimientosService.ConsultarTodos().Select(p=> new ConocimientosViewModel(p));
            return conocimientos;
        }
        [HttpGet("{identificacion}")]
        public ActionResult<ConocimientosViewModel> Get(string identificacion)
        {
            var response = _conocimientosService.Buscar(identificacion);
            if(response.Error)
            {
                 ModelState . AddModelError ( "Error al guardar conocimiento" , response. Mensaje );
                var  detallesproblemas  =  new  ValidationProblemDetails ( ModelState );
                detallesproblemas.Status  =  StatusCodes.Status500InternalServerError ;
                return  BadRequest ( detallesproblemas );
            }
            return Ok(response.Conocimientos);
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<ConocimientosViewModel> Post(ConocimientosInputModel conocimientosInput){
            Conocimientos conocimientos = MapearPersona(conocimientosInput);
            var response = _conocimientosService.Guardar(conocimientos);

            if (response.Error)
            {
                ModelState.AddModelError("Guardar Conocimientos", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
            return BadRequest(problemDetails);
            }
            return Ok(response.Conocimientos);
        }
        
        private Conocimientos MapearPersona(ConocimientosInputModel conocimientosInput){
            var conocimientos = new Conocimientos();
                conocimientos.Pregunta1 = conocimientosInput.Pregunta1;
                conocimientos.Pregunta2 = conocimientosInput.Pregunta2;
                conocimientos.Pregunta3 = conocimientosInput.Pregunta3;
                conocimientos.Pregunta4 = conocimientosInput.Pregunta4;
                conocimientos.Pregunta5 = conocimientosInput.Pregunta5;
                conocimientos.Pregunta6 = conocimientosInput.Pregunta6;
                conocimientos.Idpersona = conocimientosInput.Idpersona;
                conocimientos.Codigo = conocimientosInput.Idpersona;
            return conocimientos;
        }
    }
}