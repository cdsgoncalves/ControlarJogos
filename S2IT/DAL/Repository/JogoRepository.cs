using DAL.Contexts;
using DAL.Interfaces;
using Model.Entidades;

namespace DAL.Repository
{
    public class JogoRepository : Repository<Jogo>, IJogoRepository
    {
        public JogoRepository(S2ItContext contexto) : base(contexto)
        {

        }
    }
}