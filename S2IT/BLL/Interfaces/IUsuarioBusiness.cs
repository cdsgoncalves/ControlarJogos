using System.Linq;
using System.Web;
using Model.Entidades;

namespace BLL.Interfaces
{
    public interface IUsuarioBusiness : IBusiness<Usuario>
    {
        Usuario ObterPorEmail(string email);
        IQueryable<Usuario> Listar();
        void Deletar(int id);
        void Cadastrar(Usuario usuario);
    }
}