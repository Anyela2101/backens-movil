using Datos;
using Entidad;
using System.Linq;

namespace Logica
{
    public class UsuarioService
    {
        private readonly PersonaContext _context;
        public UsuarioService (PersonaContext context)=> _context = context;
        public Usuario Validate(string user, string password){
            return _context.Usuarios.FirstOrDefault(t => t.User == user && t.Password == password);
        }
    }
}