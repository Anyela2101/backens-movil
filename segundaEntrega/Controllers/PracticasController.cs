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
    public class PracticasController:ControllerBase
    {
        private readonly PracticasServices _practicasService;
        public PracticasController(PersonaContext context){
    
            _practicasService = new PracticasServices(context);
        }

        // GET: api/Persona
        [HttpGet()]
        public IEnumerable<PracticasViewModel> Gets(){
            var practicas = _practicasService.ConsultarTodos().Select(p=> new PracticasViewModel(p));
            return practicas;
        }
        [HttpGet("{identificacion}")]
        public ActionResult<PracticasViewModel> Get(string identificacion)
        {
            var response = _practicasService.Buscar(identificacion);
            if(response.Error)
            {
                ModelState . AddModelError ( " Error al guardar practica " , response. Mensaje );
                var  detallesproblemas  =  new  ValidationProblemDetails ( ModelState );
                detallesproblemas.Status  =  StatusCodes.Status500InternalServerError ;
                return  BadRequest ( detallesproblemas );
            }
            return Ok(response.Practicas);
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<PracticasViewModel> Post(PracticasInputModel practicasInput){
            Practicas practicas = MapearPersona(practicasInput);
            var response = _practicasService.Guardar(practicas);

            if (response.Error)
            {
                ModelState.AddModelError("Guardar Practicas", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
            return BadRequest(problemDetails);
            }
            return Ok(response.Practicas);
        }
        
        private Practicas MapearPersona(PracticasInputModel practicasInput){
            var practicas = new Practicas();
                practicas.Pregunta1 = practicasInput.Pregunta1;
                practicas.Pregunta2 = practicasInput.Pregunta2;
                practicas.Pregunta3 = practicasInput.Pregunta3;
                practicas.Pregunta4 = practicasInput.Pregunta4;
                practicas.Idpersona = practicasInput.Idpersona;
                practicas.Codigo = practicasInput.Idpersona;
            return practicas;
        }
    }
}