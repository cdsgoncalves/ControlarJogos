using Web.Models;
using System.Web.Mvc;
using System.Security.Claims;
using Model.Entidades;
using Web.Extensions;

namespace Web.Controllers
{
    public class AppController : Controller
    {
        public AppUser UsuarioLogado => new AppUser(User as ClaimsPrincipal);

        public void AtualizarClaims(Usuario usuario)
        {
            User.AddUpdateClaim("Foto", string.Concat("http://", HttpContext.Request.Url?.Authority, "/Arquivos/", ""));
            User.AddUpdateClaim("Email", usuario.Email);
            User.AddUpdateClaim("Name", usuario.Nome);
        }
    }
}