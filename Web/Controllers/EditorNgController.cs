using Goody.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goody.Web.Controllers
{
    [RoutePrefix("editorng")]
    public class EditorNgController : Controller
    {
        // GET: EditorNg
        public ActionResult Index() 
        {
            return View();
        }

        [Route("{id:int}/manage")]
        [Route("create")]
        public ActionResult Manage(int id = 0)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }
    }
}