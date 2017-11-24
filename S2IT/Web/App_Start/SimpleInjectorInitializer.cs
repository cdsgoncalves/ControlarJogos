using Web;
using Infra.IoC;
using SimpleInjector;
using System.Web.Mvc;
using WebActivatorEx;
using System.Reflection;
using Web.Util.AutoMapper;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace Web
{
    public static class SimpleInjectorInitializer
    {
        private static Container _container;

        public static T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            BootStrapper.Register(container);
            container.RegisterSingleton(MapperHelper.CreateConfiguration().CreateMapper());
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            _container = container;
        }
    }
}