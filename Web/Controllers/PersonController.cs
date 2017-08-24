using Goody.Web.Models.ViewModels;
using System.Web.Mvc;

namespace Goody.Web.Controllers
{
    [RoutePrefix("people")]
    public class PersonController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Route("create")]
        [Route("{id:int}/edit")]
        public ActionResult Manage(int id = 0)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }
    }
}