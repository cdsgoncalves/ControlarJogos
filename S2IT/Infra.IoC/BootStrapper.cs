using BLL;
using DAL.UoW;
using DAL.Contexts;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repository;
using SimpleInjector;
using Infra.Interfaces;

namespace Infra.IoC
{
    public static class BootStrapper
    {
        public static Container Container { get; set; }

        public static void Register(Container container)
        {
            // Lifestyle.Transient  => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton  => Uma instancia unica para a classe;
            // Lifestyle.Scoped     => Uma instancia unica para o request;

            Container = container;

            // Bussiness            
            container.Register<IUsuarioBusiness, UsuarioBusiness>(Lifestyle.Scoped);

            // Infra Dados Repos
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IJogoRepository, JogoRepository>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<S2ItContext>(Lifestyle.Scoped);

            // Infra Core
        }
    }
}