using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Web.Models
{
    public class AppUser : ClaimsPrincipal
    {
        public AppUser(IPrincipal principal) : base(principal)
        {

        }

        public string Nome => FindFirst(ClaimTypes.Name).Value;

        public string Email => FindFirst(ClaimTypes.Email).Value;

        public int Id => Convert.ToInt32(FindFirst("Id").Value);

        public string Foto
        {
            get
            {
                var fotoUsuario = FindFirst("Foto")?.Value;

                if (string.IsNullOrEmpty(fotoUsuario))
                    fotoUsuario = "/Content/img/default_user.png";
                else if(!fotoUsuario.Contains("http://"))
                    fotoUsuario = string.Concat("http://", HttpContext.Current.Request.Url.Authority, "/Arquivos/", fotoUsuario);

                return fotoUsuario;
            }
        }
    }
}