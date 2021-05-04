
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

        [HttpPut("PersonalRestaurante")]
        public ActionResult<RestauranteViewModel> AgregarPersonal(PersonaInputModel personaInputModel)
        {
            Persona persona = MapearPersona(personaInputModel);
            var response = _personaService.Guardar(persona);
            if(response.Error)
            {
                return BadRequest();
            }
            return Ok(response.Restaurante);
        }

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

        [HttpDelete("{nit}/{identificacion}")]
        public ActionResult<PersonaViewModel> EliminarPersona(string nit, string identificacion)
        {
            var response = _personaService.EliminarPersona(nit, identificacion);
            if (response.Error)
            {
                ModelState.AddModelError("Error al eliminar la persona", response.Mensaje);
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

        [HttpPut("UpdatePersona")]
        public ActionResult<PersonaViewModel> EditarPersona(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.EditarPersona(persona);
            if (response.Error)
            {
                ModelState.AddModelError("Error al editar la persona", response.Mensaje);
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