using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new JurosViewModel());
        }

        [HttpPost]
        public ActionResult Index(JurosViewModel model)
        {
            var urlApi = string.Format("https://localhost:5001/calculajuros?valorinicial={0}&meses={1}", model.ValorInicial, model.Tempo);

            var client = new HttpClient();
            var response = client.GetAsync(urlApi).Result;
            model.ValorFinal = response.Content.ReadAsStringAsync().Result;

            return View(model);
        }

        [HttpGet]
        public ActionResult About()
        {
            CodigoFonteViewModel model = new CodigoFonteViewModel();

            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:5001/showmethecode").Result;
            model.UrlGit = response.Content.ReadAsStringAsync().Result;

            ViewBag.Message = "Acesse o código fonte desse projeto no Git:";
            return View(model);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Quem é a Mar?";
            return View();
        }
    }
}