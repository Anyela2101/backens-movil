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
    public class ActitudesController:ControllerBase
    {
        private readonly ActitudesService _actitudesService;
        public ActitudesController(PersonaContext context){
    
            _actitudesService = new ActitudesService(context);
        }

        // GET: api/Persona
        [HttpGet()]
        public IEnumerable<ActitudesViewModel> Gets(){
            var actitudes = _actitudesService.ConsultarTodos().Select(p=> new ActitudesViewModel(p));
            return actitudes;
        }
        [HttpGet("{identificacion}")]
        public ActionResult<ActitudesViewModel> Get(string identificacion)
        {
            var response = _actitudesService.Buscar(identificacion);
            if(response.Error)
            { 
                ModelState . AddModelError ( " Error al guardar Actitudes " , response. Mensaje );
                var  detallesproblemas  =  new  ValidationProblemDetails ( ModelState );
                detallesproblemas.Status  =  StatusCodes.Status500InternalServerError ;
                return  BadRequest ( detallesproblemas );
            }
            return Ok(response.Actitudes);
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<ActitudesViewModel> Post(ActitudesInputModel actitudesInput){
            Actitudes actitudes = MapearPersona(actitudesInput);
            var response = _actitudesService.Guardar(actitudes);

            if (response.Error)
            {
                ModelState.AddModelError("Guardar Conocimientos", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
            return BadRequest(problemDetails);
            }
            return Ok(response.Actitudes);
        }
        
        private Actitudes MapearPersona(ActitudesInputModel actitudesInput){
            var actitudes = new Actitudes();
                actitudes.Pregunta1 = actitudesInput.Pregunta1;
                actitudes.Pregunta2 = actitudesInput.Pregunta2;
                actitudes.Pregunta3 = actitudesInput.Pregunta3;
                actitudes.Pregunta4 = actitudesInput.Pregunta4;
                actitudes.Pregunta5 = actitudesInput.Pregunta5;
                actitudes.Pregunta6 = actitudesInput.Pregunta6;
                actitudes.Idpersona = actitudesInput.Idpersona;
                actitudes.Codigo = actitudesInput.Idpersona;
            return actitudes;
        }
    }
}