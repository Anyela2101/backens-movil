using System.ComponentModel.DataAnnotations;

namespace Entidad

{
    public class Usuario
    {
        [Key]
        public string User { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token {get;set;}

    }
}