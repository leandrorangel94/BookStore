using BookStore.Domain;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("teste")]
    public class TesteController : Controller
    {
        public ViewResult Dados(int Id)
        {
            var autor = new Autor
            {
                Id = 1,
                Nome = "Leandro Rangel"
            };

            ViewBag.Categoria = "Produtos de Limpeza";
            ViewData["Categoria"] = "Produtos de Informatica";
            TempData["Categoria"] = "Produtos de Escritorio";
            Session["Categoria"] = "Moveis";

            return View(autor);
        }

        public string Index(int id)
        {
            return "Index do " + id.ToString();
        }

        public JsonResult UmaAction(int id, string nome)
        {
            var autor = new Autor
            {
                Id = id,
                Nome = nome

            };
            return Json(autor, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ActionName("Autor")]
        public JsonResult ActionDois(Autor autor)
        {
            return Json(autor);
        }

        [Route("minharota/{id:int}")]
        public string MinhaAction(int id)
        {
            return "Ok! Cheguei na rota!";
        }

        [Route("~/rotaignorada/{id:int}")]
        public string MinhaAction2(int id)
        {
            return "Ok! Cheguei na rota!";
        }

        [Route("rota/{categoria:alpha:minlength(3)}")]
        public string MinhaAction3(string categoria)
        {
            return "Ok! Cheguei na rota!" + categoria;
        }

        /*[Route("rota/estacao/{estacao:(primavera|verao|outono|inverno)}")]
        public string MinhaAction4(string estacao)
        {
            return "Olá! Estamos no " + estacao;
        }*/
    }
}