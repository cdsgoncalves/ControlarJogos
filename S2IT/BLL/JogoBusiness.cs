using BLL.Interfaces;
using DAL.Interfaces;
using Model.Entidades;

namespace BLL
{
    public class JogoBusiness : Business<Jogo>, IJogoBusiness
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoBusiness(IJogoRepository jogoRepository) : base(jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }
    }
}