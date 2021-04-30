using System;
using Entidad;

namespace segundaEntrega.Models
{
    public class RestauranteInputModel{
        public string Nit {get;set;}
        public string Nombre {get;set;}
        public string Propietario {get;set;}
        public string Direccion {get;set;}
        public int CantidadPersonal {get;set;}
        public string Telefono {get;set;}
        public string Email {get;set;}
        public int Sedes {get;set;}
        public int AñoFuncionamiento {get;set;}
        public string Especialidad {get;set;}
    }
    public class RestauranteInputModeltwo{
        public string Nit {get;set;}
        public string Nombre {get;set;}
        public string Propietario {get;set;}
        public string Direccion {get;set;}
        public int CantidadPersonal {get;set;}
        public string Telefono {get;set;}
        public string Email {get;set;}
        public int Sedes {get;set;}
        public int AFuncionamiento {get;set;}
        public string Especialidad {get;set;}
    }
    public class RestauranteViewModel : RestauranteInputModel
    {
        public RestauranteViewModel()
        {

        }
        public RestauranteViewModel(Restaurante restaurante)
        {
            Nit = restaurante.NIT;
            Nombre = restaurante.Nombre;
            Propietario = restaurante.Propietario;
            Direccion = restaurante.Direccion;
            CantidadPersonal = restaurante.CantidadPersonal;
            Telefono = restaurante.Telefono;
            Email = restaurante.Email;
            Sedes = restaurante.Sedes;
            AñoFuncionamiento=restaurante.AñoFuncionamiento;
            Especialidad =restaurante.Especialidad;  
        }
    }
    public class RestauranteViewModeltwo : RestauranteInputModeltwo
    {
        public RestauranteViewModeltwo()
        {

        }
        public RestauranteViewModeltwo(Restaurantetwo restaurante)
        {
            Nit = restaurante.NIT;
            Nombre = restaurante.Nombre;
            Propietario = restaurante.Propietario;
            Direccion = restaurante.Direccion;
            CantidadPersonal = restaurante.CantidadPersonal;
            Telefono = restaurante.Telefono;
            Email = restaurante.Email;
            Sedes = restaurante.Sedes;
            AFuncionamiento=restaurante.AFuncionamiento;
            Especialidad =restaurante.Especialidad;  
        }
    }
}