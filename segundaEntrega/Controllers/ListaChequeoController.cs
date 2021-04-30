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
    public class ListaChequeoController:ControllerBase
    {
        private readonly ListaChequeoService _listaChequeoService;
        public ListaChequeoController(PersonaContext context){
    
            _listaChequeoService = new ListaChequeoService(context);
        }

        // GET: api/Persona
        [HttpGet()]
        public IEnumerable<ListaChequeoViewModel> Gets(){
            var listaChequeos = _listaChequeoService.ConsultarTodos().Select(p=> new ListaChequeoViewModel(p));
            return listaChequeos;
        }

        [HttpGet("{nit}")]
        public ActionResult<ListaChequeoViewModel> Get(string nit)
        {
            var response = _listaChequeoService.Buscar(nit);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.ListaChequeo);
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<ConocimientosViewModel> Post(ListaChequeoInputModel listaChequeoInput){
            ListaChequeo listaChequeo = MapearListaChequeo(listaChequeoInput);
            var response = _listaChequeoService.Guardar(listaChequeo);

            if (response.Error)
            {
                ModelState.AddModelError("Guardar ListaChequeo", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
            return BadRequest(problemDetails);
            }
            return Ok(response.ListaChequeo);
        }
        
        private ListaChequeo MapearListaChequeo(ListaChequeoInputModel listaChequeoInput){
            var listaChequeo = new ListaChequeo();
                listaChequeo.Pregunta1 = listaChequeoInput.Pregunta1;
                listaChequeo.Pregunta2 = listaChequeoInput.Pregunta2;
                listaChequeo.Pregunta3 = listaChequeoInput.Pregunta3;
                listaChequeo.Pregunta4 = listaChequeoInput.Pregunta4;
                listaChequeo.Pregunta5 = listaChequeoInput.Pregunta5;
                listaChequeo.Pregunta6 = listaChequeoInput.Pregunta6;
                listaChequeo.Pregunta7 = listaChequeoInput.Pregunta7;
                listaChequeo.Pregunta8 = listaChequeoInput.Pregunta8;
                listaChequeo.Pregunta9 = listaChequeoInput.Pregunta9;

                listaChequeo.nit = listaChequeoInput.nit;
                listaChequeo.Codigo = listaChequeoInput.nit;
            return listaChequeo;
        }
    }
}