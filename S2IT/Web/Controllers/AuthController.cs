using System.Security.Claims;
using System.Web;
using Web.Models;
using System.Web.Mvc;
using BLL.Interfaces;
using Microsoft.Owin.Security;
using Model.Entidades;
using Util;
using Util.Exceptions;

namespace Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("auth")]
    public class AuthController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public AuthController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpGet]
        [Route("login")]
        public ActionResult LogIn(string returnUrl) => View(new LogInModel { ReturnUrl = returnUrl });

        [HttpPost]
        [Route("login")]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                if (!Validacao.ValidarEmail(model.Email))
                    throw new S2ItException($"Email {model.Email} tem um formato inválido.");

                var usuario = _usuarioBusiness.ObterPorEmail(model.Email);

                if (usuario == null || !usuario.Ativo || !Criptografia.ValorCorretamenteCriptografado(model.Senha, usuario.Senha))
                    throw new S2ItException("Email ou senha inválidos.");

                AuthenticationManagerSigIn(usuario, model.Lembrar);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
            catch (S2ItException s2ItEx)
            {
                ModelState.AddModelError("", s2ItEx.Message);
                return View();
            }
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                return Url.Action("Index", "Home");

            return returnUrl;
        }

        [Route("sair")]
        public ActionResult LogOut()
        {
            var ctx = System.Web.HttpContext.Current.Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

        #region === Métodos privados ===
        private static ClaimsIdentity DefinirClaims(Usuario usuario)
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("Id", usuario.Id.ToString()),
            }, "ApplicationCookie");
        }

        private static void AuthenticationManagerSigIn(Usuario usuario, bool persistir)
        {
            var identity = DefinirClaims(usuario);
            var ctx = System.Web.HttpContext.Current.Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignIn(new AuthenticationProperties { IsPersistent = persistir }, identity);
        }
        #endregion
    }
}