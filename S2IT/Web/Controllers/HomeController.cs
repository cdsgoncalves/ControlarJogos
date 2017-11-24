using System.Web.Mvc;
using AutoMapper;
using BLL.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    [RoutePrefix("dashboard")]
    public class HomeController : AppController
    {
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IMapper _mapper;

        public HomeController(IUsuarioBusiness usuarioBusiness, IMapper mapper)
        {
            _usuarioBusiness = usuarioBusiness;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var modelo = new DashboardViewModel();
            return View(modelo);
        }
    }
}