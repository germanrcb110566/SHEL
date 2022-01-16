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
        [HttpGet]
        public JsonResult Catalogo(int IdCatalogo)
        {
            List<ElementJsonIntKey> lst = new List<ElementJsonIntKey>();
            using (Models.SHELEntities db=new Models.SHELEntities())
            {
                lst = (from d in db.Catalogo
                       where d.catalogo_id == IdCatalogo
                       select new ElementJsonIntKey
                       {
                           Value = d.registro_id,
                           Text = d.nombre
                       }).ToList();
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public class ElementJsonIntKey
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }
    }
}