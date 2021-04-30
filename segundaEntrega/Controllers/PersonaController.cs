
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using segundaEntrega.Models;
using Datos;

namespace segundaEntrega.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController :  ControllerBase
    {
        private readonly PersonaService _personaService;
        public PersonaController(PersonaContext context){
    
            _personaService = new PersonaService(context);
        }

        // GET: api/Persona
        [HttpGet()]
        public IEnumerable<PersonaViewModel> Gets(){
            var personas = _personaService.ConsultarTodos().Select(p=> new PersonaViewModel(p));
            return personas;
        }
        /* [HttpGet("{nit}")]
        public IEnumerable<PersonaViewModel> Gets(string nit){
            var personas = _personaService.ConsultarTodosxNit(nit).Select(p=> new PersonaViewModel(p));
            return personas;
        }
 */


        [HttpGet("{identificacion}")]
        public ActionResult<PersonaViewModel> Get(string identificacion)
        {
            var response = _personaService.Buscar(identificacion);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput){
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);

            if (response.Error)
            {
                ModelState.AddModelError("Guardar Persona", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
            return BadRequest(problemDetails);
            }
            return Ok(response.Persona);
        }
        
        private Persona MapearPersona(PersonaInputModel personaInput){
            var persona = new Persona();
            
                persona.Identificacion = personaInput.Identificacion;
                persona.Nombres = personaInput.Nombres;
                persona.Apellidos = personaInput.Apellidos;
                persona.Sexo = personaInput.Sexo;
                persona.Edad = personaInput.Edad; 
                persona.Telefono=personaInput.Telefono;   
                persona.Email = personaInput.Email;
                persona.EstadoCivil=personaInput.EstadoCivil;
                persona.PaisProcedencia = personaInput.PaisProcedencia;
                persona.NivelEducativo=personaInput.NivelEducativo;
                persona.Idrestaurante = personaInput.Idrestaurante;
                persona.Usuario = personaInput.Usuario;
            return persona;
        }
    }
}