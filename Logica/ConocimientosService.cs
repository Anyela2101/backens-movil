using System.IO.Pipes;
using System.Security.Permissions;
using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;


namespace Logica
{
    public class ConocimientosService
    {
        private readonly PersonaContext _context;
        public ConocimientosService(PersonaContext context){
            _context=context;
        }

         public GuardarConocimientosResponse Guardar(Conocimientos conocimientos)
        {
            try
            {
                var personaBuscada = _context.Conocimientos.Find(conocimientos.Codigo);
                if(personaBuscada != null){
                    return new GuardarConocimientosResponse("Error, la persona ya se encuentra registrarada");
                }
                conocimientos.Calcularpuntos();
                _context.Conocimientos.Add(conocimientos);
                _context.SaveChanges();
                return new GuardarConocimientosResponse(conocimientos);
            }
            catch (Exception e)
            {
                return new GuardarConocimientosResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { }
        }
        public GuardarConocimientosResponse Buscar(string Identificacion){
            Conocimientos conocimientos = _context.Conocimientos.Find(Identificacion);
            if(conocimientos == null){
                return new GuardarConocimientosResponse("No existe");
            }
            return new GuardarConocimientosResponse(conocimientos);
        }
        
        public List<Conocimientos> ConsultarTodos()
        {
            List<Conocimientos> conocimientos = _context.Conocimientos.ToList();

            return conocimientos;
        }

    public class GuardarConocimientosResponse 
    {
        public GuardarConocimientosResponse(Conocimientos conocimientos)
        {
            Error = false;
            Conocimientos = conocimientos;
        }
        public GuardarConocimientosResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Conocimientos Conocimientos { get; set; }

    }
}
}
