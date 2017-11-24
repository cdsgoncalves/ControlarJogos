using AutoMapper;
using Web.Helpers;
using System.Web.Mvc;
using BLL.Interfaces;
using Model.Entidades;
using Util.Exceptions;
using DataTablesParser;
using Web.Extensions;
using Web.Models;

namespace Web.Controllers
{
    [RoutePrefix("usuario")]
    public class UsuarioController : AppController
    {
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioBusiness usuarioBusiness, IMapper mapper)
        {
            _usuarioBusiness = usuarioBusiness;
            _mapper = mapper;
        }

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("listar")]
        public JsonResult Listar()
        {
            var usuarios = _usuarioBusiness.Listar();
            var parser = new DataTablesParser<Usuario>(Request, usuarios);
            var data = parser.Parse();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("novo")]
        public ActionResult Adicionar()
        {
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(UsuarioViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View("Adicionar", modelo);
            }

            var usuario = _mapper.Map<Usuario>(modelo);

            try
            {
                _usuarioBusiness.Cadastrar(usuario);
                return RedirectToAction("Index").Success($"O usuário <b>{usuario.Nome}</b> foi adicionado com sucesso!");
            }
            catch (S2ItException s2ItEx)
            {
                return View("Adicionar", modelo).Error(s2ItEx.Message);
            }
        }

        [HttpGet]
        [Route("{id}/editar")]
        public ActionResult Editar(int id)
        {
            var usuario = _usuarioBusiness.ObterPorId(id);

            if (usuario == null)
                throw new S2ItException($"Nenhum usuário associado ao id {id}");

            if (usuario.Email.Equals("dev@assino.com.br"))
                throw new S2ItException($"Não é possível editar o usuário {usuario.Email}");

            return View(_mapper.Map<UsuarioViewModel>(usuario));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(UsuarioViewModel modelo)
        {
            if (!ModelState.IsValid)
                return View("Editar", modelo).Error(ModelState.TodosErros());

            var usuario = _mapper.Map<Usuario>(modelo);

            try
            {
                _usuarioBusiness.Atualizar(usuario);

                if (modelo.Id == UsuarioLogado.Id)
                    AtualizarClaims(usuario);

                return RedirectToAction("Index").Success($"O usuário com o ID {modelo.Id} foi atualizado com sucesso.");
            }
            catch (S2ItException s2ItEx)
            {
                return View("Editar", modelo).Error(s2ItEx.Message);
            }
        }

        [HttpGet]
        [Route("{id}/deletar")]
        public ActionResult Deletar(int id)
        {
            if (id == UsuarioLogado.Id)
                return Json(new { Message = "Você não pode deletar sua própria conta." }, JsonRequestBehavior.AllowGet);

            try
            {
                _usuarioBusiness.Deletar(id);
                return RedirectToAction("Index").Success($"O usuário com o ID {id} foi deletado com sucesso.");
            }
            catch (S2ItException s2ItEx)
            {
                return Json(new { s2ItEx.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}