using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;


namespace Logica
{
    public class PracticasServices
    {
        private readonly PersonaContext _context;
        public PracticasServices(PersonaContext context){
            _context=context;
        }

         public GuardarPracticasResponse Guardar(Practicas practicas)
        {
            try
            {
                var personaBuscada = _context.Practicas.Find(practicas.Codigo);
                if(personaBuscada != null){
                    return new GuardarPracticasResponse("Error, la persona ya se encuentra registrarada");
                }
                practicas.Calcularpuntos();
                _context.Practicas.Add(practicas);
                _context.SaveChanges();
                return new GuardarPracticasResponse(practicas);
            }
            catch (Exception e)
            {
                return new GuardarPracticasResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { }
        }
        
        public List<Practicas> ConsultarTodos()
        {
            List<Practicas> Practicas = _context.Practicas.ToList();

            return Practicas;
        }
        public GuardarPracticasResponse Buscar(string Identificacion){
            Practicas practicas = _context.Practicas.Find(Identificacion);
            if(practicas == null){
                return new GuardarPracticasResponse("No existe");
            }
            return new GuardarPracticasResponse(practicas);
        }

    public class GuardarPracticasResponse 
    {
        public GuardarPracticasResponse(Practicas practicas)
        {
            Error = false;
            Practicas = practicas;
        }
        public GuardarPracticasResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Practicas Practicas { get; set; }

    }
}
}