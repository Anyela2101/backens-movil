using System.IO.Pipes;
using System.Security.Permissions;
using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;


namespace Logica
{
    public class ActitudesService
    {
        private readonly PersonaContext _context;
        public ActitudesService(PersonaContext context){
            _context=context;
        }

         public GuardarActitudesResponse Guardar(Actitudes actitudes)
        {
            try
            {
                var personaBuscada = _context.Actitudes.Find(actitudes.Codigo);
                if(personaBuscada != null){
                    return new GuardarActitudesResponse("Error, la persona ya se encuentra registrarada");
                }
                actitudes.Calcularpuntos();
                _context.Actitudes.Add(actitudes);
                _context.SaveChanges();
                return new GuardarActitudesResponse(actitudes);
            }
            catch (Exception e)
            {
                return new GuardarActitudesResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { }
        }
        public GuardarActitudesResponse Buscar(string Identificacion){
            Actitudes actitudes = _context.Actitudes.Find(Identificacion);
            if(actitudes == null){
                return new GuardarActitudesResponse("No existe");
            }
            return new GuardarActitudesResponse(actitudes);
        }
        public List<Actitudes> ConsultarTodos()
        {
            List<Actitudes> actitudes = _context.Actitudes.ToList();
            return actitudes;
        }

    public class GuardarActitudesResponse 
    {
        public GuardarActitudesResponse(Actitudes actitudes)
        {
            Error = false;
            Actitudes = actitudes;
        }
        public GuardarActitudesResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Actitudes Actitudes { get; set; }

    }
}
}