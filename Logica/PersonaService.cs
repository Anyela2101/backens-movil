using System.IO.Pipes;
using System.Security.Permissions;
using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;


namespace Logica
{
    public class PersonaService
    {
        private readonly PersonaContext _context;
        public PersonaService(PersonaContext context){
            _context=context;
        }

         public AgregarPersonaRestauranteResponse Guardar(Persona persona)
        {
            try
            {
                var personaBuscada = _context.Personas.Find(persona.Identificacion);
                if(personaBuscada != null)
                {
                    return new AgregarPersonaRestauranteResponse("Error, la persona ya se encuentra registrada", "Existe");
                }

                var response = _context.Restaurantes.Find(persona.Idrestaurante);
                if(response == null)
                {
                    return new AgregarPersonaRestauranteResponse("Error, no existe el restaurante", "NoExiste");
                }
                response.Personals.Add(persona);
                _context.Restaurantes.Update(response);
                _context.SaveChanges();
                return new AgregarPersonaRestauranteResponse(response);
            }
            catch (Exception e)
            {
                return new AgregarPersonaRestauranteResponse($"Error de la Aplicacion  : {e.Message}", "Error");
            }
            finally { }
        }
         public GuardarPersonaResponse Buscar(string Identificacion){
            Persona persona = _context.Personas.Find(Identificacion);
            if(persona == null){
                return new GuardarPersonaResponse("No existe");
            }
            return new GuardarPersonaResponse(persona);
        }
        
        public List<Persona> ConsultarTodos()
        {
            List<Persona> personas = _context.Personas.ToList();

            return personas;
        }
        public List<Persona> ConsultarTodosxNit(string nit)
        {
            List<Persona> personas = _context.Personas.Where(p=>p.Idrestaurante==nit).ToList();

            return personas;
        }

    public class AgregarPersonaRestauranteResponse
    {
        public AgregarPersonaRestauranteResponse(Restaurante restaurante)
        {
            Error = false;
            Restaurante = restaurante;
        }
        public AgregarPersonaRestauranteResponse(string mensaje, string estado)
        {
            Error = true;
            Mensaje = mensaje;
            Estado = estado;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public string Estado { get; set; }
        public Restaurante Restaurante { get; set; }
    }
    public class GuardarPersonaResponse 
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }

    }
}
}
