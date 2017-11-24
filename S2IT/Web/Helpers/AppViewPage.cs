using Web.Models;
using System.Web.Mvc;
using System.Security.Claims;

namespace Web.Helpers
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUser UsuarioLogado => new AppUser(User as ClaimsPrincipal);
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {

    }
}