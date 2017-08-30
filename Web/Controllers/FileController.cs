using System.Web.Mvc;

namespace Goody.Web.Controllers
{
    public class FileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }
    }
}