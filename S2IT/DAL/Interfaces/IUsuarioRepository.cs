using Model.Entidades;

namespace DAL.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterPorEmail(string email);
    }
}