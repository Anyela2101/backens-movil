using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;


namespace Logica
{
    public class ListaChequeoService
    {
        private readonly PersonaContext _context;
        public ListaChequeoService(PersonaContext context){
            _context=context;
        }

         public GuardarListaChequeoResponse Guardar(ListaChequeo listaChequeo)
        {
            try
            {
                var personaBuscada = _context.Actitudes.Find(listaChequeo.Codigo);
                if(personaBuscada != null){
                    return new GuardarListaChequeoResponse("Error, la persona ya se encuentra registrarada");
                }
                listaChequeo.Calcularpuntos();
                _context.ListaChequeos.Add(listaChequeo);
                _context.SaveChanges();
                return new GuardarListaChequeoResponse(listaChequeo);
            }
            catch (Exception e)
            {
                return new GuardarListaChequeoResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { }
        }
        
        public List<ListaChequeo> ConsultarTodos()
        {
            List<ListaChequeo> listaChequeos = _context.ListaChequeos.ToList();
            return listaChequeos;
        }
        public GuardarListaChequeoResponse Buscar(string codifo){
            ListaChequeo listaChequeo = _context.ListaChequeos.Find(codifo);
            if(listaChequeo == null){
                return new GuardarListaChequeoResponse("No existe");
            }
            return new GuardarListaChequeoResponse(listaChequeo);
        }

    public class GuardarListaChequeoResponse 
    {
        public GuardarListaChequeoResponse(ListaChequeo listaChequeo)
        {
            Error = false;
            ListaChequeo = listaChequeo;
        }
        public GuardarListaChequeoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ListaChequeo ListaChequeo { get; set; }

    }
}
}