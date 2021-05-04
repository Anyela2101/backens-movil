using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class RestauranteService
    {
        private readonly PersonaContext _context;

        public RestauranteService(PersonaContext context)
        {
            _context = context;
        }

        public GuardarRestauranteResponse Guardar(Restaurante restaurante)
        {
            try
            {
                var restauranteBuscada =
                    _context.Restaurantes.Find(restaurante.NIT);
                if (restauranteBuscada != null)
                {
                    return new GuardarRestauranteResponse("Error, ya registrarada");
                }
                _context.Restaurantes.Add (restaurante);
                _context.SaveChanges();
                return new GuardarRestauranteResponse(restaurante);
            }
            catch (Exception e)
            {
                return new GuardarRestauranteResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally
            {
            }
        }

        public List<Restaurante> ConsultarTodos()
        {
            List<Restaurante> restaurantes = _context.Restaurantes.Include(r => r.Personals).ToList();
            return restaurantes;
        }

        public List<Restaurantetwo> ConsultarTodostwo()
        {
            List<Restaurante> restaurantes = _context.Restaurantes.ToList();
            List<Restaurantetwo> restaurantestwo = new List<Restaurantetwo>();
            foreach (var item in restaurantes)
            {
                Restaurantetwo restaurantetwo = new Restaurantetwo();
                restaurantetwo.NIT = item.NIT;
                restaurantetwo.Nombre = item.Nombre;
                restaurantetwo.Propietario = item.Propietario;
                restaurantetwo.Sedes = item.Sedes;
                restaurantetwo.Telefono = item.Telefono;
                restaurantetwo.AFuncionamiento = item.AñoFuncionamiento;
                restaurantetwo.CantidadPersonal = item.CantidadPersonal;
                restaurantetwo.Direccion = item.Direccion;
                restaurantetwo.Email = item.Email;
                restaurantetwo.Especialidad = item.Especialidad;
            }
            return restaurantestwo;
        }

        public GuardarRestauranteResponse Buscar(string nombre)
        {
            Restaurante restaurante = _context.Restaurantes.Find(nombre);
            if (restaurante == null)
            {
                return new GuardarRestauranteResponse("No existe");
            }
            return new GuardarRestauranteResponse(restaurante);
        }

        public EditarRestauranteResponse EditarRestaurante(Restaurante restaurante)
        {
            try
            {
                var response = _context.Restaurantes.Find(restaurante.NIT);
                if (response != null)
                {
                    response.Nombre = restaurante.Nombre;
                    response.Propietario = restaurante.Propietario;
                    response.Direccion = restaurante.Direccion;
                    response.CantidadPersonal = restaurante.CantidadPersonal;
                    response.Telefono = restaurante.Telefono;
                    response.Email = restaurante.Email;
                    response.Sedes = restaurante.Sedes;
                    response.AñoFuncionamiento = restaurante.AñoFuncionamiento;
                    response.Especialidad = restaurante.Especialidad;
                    _context.Restaurantes.Update (response);
                    _context.SaveChanges();
                    return new EditarRestauranteResponse(response);
                }
                else
                {
                    return new EditarRestauranteResponse("No se encontro el Restaurante",
                        "NoExiste");
                }
            }
            catch (Exception e)
            {
                return new EditarRestauranteResponse($"Error en la aplicacion: {e.Message}",
                    "Error");
            }
        }

        public EliminarRestauranteResponse EliminarRestaurante(string nit)
        {
            try
            {
                var restaurantes = _context.Restaurantes.Include(r => r.Personals).ToList();
                var response = restaurantes.Find(r=> r.NIT == nit);
                if(response != null)
                {
                    _context.Restaurantes.Remove(response);
                    foreach (var item in response.Personals)
                    {
                        _context.Personas.Remove(item);
                    }
                    _context.SaveChanges();
                    return new EliminarRestauranteResponse(response);
                }
                else
                {
                    return new EliminarRestauranteResponse("No se encuentra el restaurante","NoExiste");
                }
            }
            catch(Exception e)
            {
                return new EliminarRestauranteResponse($"Error en la aplicacion: {e.Message}",
                    "Error");
            }
        }

        public class EliminarRestauranteResponse
        {
            public EliminarRestauranteResponse(Restaurante restaurante)
            {
                Error = false;
                Restaurante = restaurante;
            }
            public EliminarRestauranteResponse(string mensaje, string estado)
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

        public class EditarRestauranteResponse
        {
            public EditarRestauranteResponse(Restaurante restaurante)
            {
                Error = false;
                Restaurante = restaurante;
            }

            public EditarRestauranteResponse(string mensaje, string estado)
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

        public class GuardarRestauranteResponse
        {
            public GuardarRestauranteResponse(Restaurante restaurante)
            {
                Error = false;
                Restaurante = restaurante;
            }

            public GuardarRestauranteResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Restaurante Restaurante { get; set; }
        }
    }
}
