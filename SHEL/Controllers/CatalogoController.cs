using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHEL.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Index()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            using (Models.SHELEntities db = new Models.SHELEntities())
            {
                lst = (from d in db.mCatalogo                
                       select new SelectListItem
                       {
                           Value = d.registro_id.ToString(),
                           Text = d.catalogo
                       }).ToList();

            }
                return View(lst);
        }
    }
}