using Goody.Web.Models.ViewModels;
using System.Web.Mvc;

namespace Goody.Web.Controllers
{
    [RoutePrefix("editor")]
    public class EditorController : Controller
    {
        // GET: Editor
        public ActionResult Index()
        {
            return View();
        }

        [Route("{id:int}/edit")]
        [Route("create")]
        public ActionResult Edit(int id = 0) {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }
    }
}