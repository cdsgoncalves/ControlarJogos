using System.Linq;
using DAL.Contexts;
using DAL.Interfaces;
using Model.Entidades;

namespace DAL.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(S2ItContext contexto) : base(contexto)
        {

        }

        public Usuario ObterPorEmail(string email) => Contexto.Set<Usuario>().FirstOrDefault(p => p.Email.Equals(email, System.StringComparison.InvariantCultureIgnoreCase));
    }
}