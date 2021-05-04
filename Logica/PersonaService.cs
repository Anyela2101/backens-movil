using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Permissions;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class PersonaService
    {
        private readonly PersonaContext _context;

        public PersonaService(PersonaContext context)
        {
            _context = context;
        }

        public AgregarPersonaRestauranteResponse Guardar(Persona persona)
        {
            try
            {
                var personaBuscada =
                    _context.Personas.Find(persona.Identificacion);
                if (personaBuscada != null)
                {
                    return new AgregarPersonaRestauranteResponse("Error, la persona ya se encuentra registrada",
                        "Existe");
                }

                var restaurantes = _context.Restaurantes.Include(r => r.Personals).ToList();
                var response = restaurantes.Find(r => r.NIT == persona.Idrestaurante);
                if (response == null)
                {
                    return new AgregarPersonaRestauranteResponse("Error, no existe el restaurante",
                        "NoExiste");
                }
                response.Personals.Add (persona);
                _context.Restaurantes.Update (response);
                _context.SaveChanges();
                return new AgregarPersonaRestauranteResponse(response);
            }
            catch (Exception e)
            {
                return new AgregarPersonaRestauranteResponse($"Error de la Aplicacion  : {e.Message}",
                    "Error");
            }
        }

        public GuardarPersonaResponse Buscar(string Identificacion)
        {
            Persona persona = _context.Personas.Find(Identificacion);
            if (persona == null)
            {
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
            List<Persona> personas =
                _context.Personas.Where(p => p.Idrestaurante == nit).ToList();

            return personas;
        }

        public EliminarPersonaRestauranteResponse EliminarPersona(string nit, string identificacion)
        {
            try
            {
                var restaurantes = _context.Restaurantes.Include(r => r.Personals).ToList();
                var response = restaurantes.Find(r => r.NIT == nit);
                if(response != null)
                {
                    var personaResponse = response.Personals.Find(p => p.Identificacion == identificacion);
                    if(personaResponse != null)
                    {
                        response.Personals.Remove(personaResponse);
                        _context.Personas.Remove(personaResponse);
                        _context.SaveChanges();
                        return new EliminarPersonaRestauranteResponse(response);
                    }
                    else
                    {
                        return new EliminarPersonaRestauranteResponse("No existe la persona","NoExiste");
                    }
                }
                else
                {
                    return new EliminarPersonaRestauranteResponse("No Existe el restaurante","NoExiste");
                }
            }
            catch(Exception e)
            {
                return new EliminarPersonaRestauranteResponse($"Error en la aplicacion: {e.Message}", "Error");
            } 
        }

        public EditarPersonaResponse EditarPersona(Persona persona)
        {
            try
            {
                var response = _context.Personas.Find(persona.Identificacion);
                if(response != null)
                {
                    response.Apellidos = persona.Apellidos;
                    response.Edad = persona.Edad;
                    response.EstadoCivil = persona.EstadoCivil;
                    response.NivelEducativo = persona.NivelEducativo;
                    response.Nombres = persona.Nombres;
                    response.PaisProcedencia = persona.PaisProcedencia;
                    response.Sexo = persona.Sexo;
                    response.Telefono = persona.Telefono;
                    _context.Personas.Update(response);
                    _context.SaveChanges();
                    var restaurante = _context.Restaurantes.Find(response.Idrestaurante);
                    return new EditarPersonaResponse(restaurante);
                }
                else
                {
                    return new EditarPersonaResponse("No existe la persona","NoExiste");
                }
            }
            catch(Exception e)
            {
                return new EditarPersonaResponse($"Error en la aplicacion: {e.Message}", "Error");
            }
        }

        public class EditarPersonaResponse
        {
            public EditarPersonaResponse(Restaurante restaurante)
            {
                Error = false;
                Restaurante = restaurante;
            }
            public EditarPersonaResponse(string mensaje, string estado)
            {
                Error = true;
                Mensaje = mensaje;
                Estado = estado;
            }
            public bool Error { get; set; }
            public string Estado { get; set; }
            public string Mensaje { get; set; }
            public Restaurante Restaurante { get; set; }
        }
        public class EliminarPersonaRestauranteResponse
        {
            public EliminarPersonaRestauranteResponse(Restaurante restaurante)
            {
                Error = false;
                Restaurante = restaurante;
            }
            public EliminarPersonaRestauranteResponse(string mensaje, string estado)
            {
                Error = true;
                Mensaje = mensaje;
                Estado = estado;
            }
            public bool Error { get; set; }
            public string Estado { get; set; }
            public string Mensaje { get; set; }
            public Restaurante Restaurante { get; set; }
        }
        public class AgregarPersonaRestauranteResponse
        {
            public AgregarPersonaRestauranteResponse(Restaurante restaurante)
            {
                Error = false;
                Restaurante = restaurante;
            }

            public AgregarPersonaRestauranteResponse(
                string mensaje,
                string estado
            )
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
