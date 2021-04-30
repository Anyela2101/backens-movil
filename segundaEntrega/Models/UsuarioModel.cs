using System;
using Entidad;

namespace segundaEntrega.Models
{
    public class UsuarioInputModel
    {
        public string User {get;set;}
        public string Password {get;set;}
        public string Tipo { get; set; }
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Token {get;set;}

    }

    public class UsuarioViewModel : UsuarioInputModel{
        public UsuarioViewModel()
        {

        }
        public UsuarioViewModel(Usuario usuario){
            User = usuario.User;
            FirstName = usuario.FirstName;
            LastName = usuario.LastName;
            Email = usuario.Email;
            Token = usuario.Token;
            Tipo = usuario.Tipo;
        }

    }
}