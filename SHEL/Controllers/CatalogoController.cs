using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHEL.Models.TableViewModels;
using SHEL.Models.ViewModel;
using SHEL.Models;



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
                       where d.estado == true
                       orderby d.catalogo
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
                       where d.catalogo_id == IdCatalogo && 
                       d.estado==true
                       orderby d.nombre
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

        public  ActionResult Grabar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Grabar(CatalogosViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new SHEL.Models.SHELEntities())
            {

                mCatalogo oParametros = new mCatalogo
                {
                    catalogo = model.Catalogo,
                    estado = true
                    
                };

                db.mCatalogo.Add(oParametros);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception Ex)
                {
                    ViewBag.Alert = "Error al Grabar: " + Ex.Message.ToString();                  
                    TempData["msg"] = "<script>alert('" + ViewBag.Alert + "');</script>";

                }
            }
            return Redirect(Url.Content("~/Catalogo/"));
        }


        [HttpGet]
        public ActionResult Editar(string Id)
        {
            
            EditCatalogoViewModel model = new EditCatalogoViewModel();
            using (var db = new SHELEntities())
            {
                var oParametros = db.mCatalogo.Find(Convert.ToInt32(Id));
                model.Catalogo = oParametros.catalogo;
                model.Registro_id = oParametros.registro_id;
            }
            return View(model);
            
        }

        
        [HttpPost]
        public ActionResult Editar(EditCatalogoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new SHELEntities())
            {
                var oParametros = db.mCatalogo.Find(model.Registro_id);
                oParametros.catalogo = model.Catalogo;

                db.Entry(oParametros).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return Redirect(Url.Content("~/Catalogo/"));
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            EditCatalogoViewModel model = new EditCatalogoViewModel();
            using (var db = new SHELEntities())
            {
                var oParametros = db.mCatalogo.Find(Convert.ToInt32(Id));
                model.Catalogo = oParametros.catalogo;
                model.Registro_id = oParametros.registro_id;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Eliminar(EditCatalogoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new SHELEntities())
            {
                var oParametros = db.mCatalogo.Find(model.Registro_id);
                oParametros.catalogo = model.Catalogo;
                oParametros.estado = false;
                db.Entry(oParametros).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return Redirect(Url.Content("~/Catalogo/"));
        }




        public ActionResult GrabarAtributo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GrabarAtributo(EditAtributosCatalogoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new SHEL.Models.SHELEntities())
            {

                Catalogo oParametros = new Catalogo
                {
                    catalogo_id = model.Catalogo_id ,
                    nombre= model.Nombre,
                    descripcion = model.Descripcion,
                    estado = true

                };

                db.Catalogo.Add(oParametros);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception Ex)
                {
                    ViewBag.Alert = "Error al Grabar: " + Ex.Message.ToString();
                    TempData["msg"] = "<script>alert('" + ViewBag.Alert + "');</script>";

                }
            }
            return Redirect(Url.Content("~/Catalogo/"));
        }


        [HttpGet]
        public ActionResult EditarAtributo(string Id)
        {

            EditAtributosCatalogoViewModel model = new EditAtributosCatalogoViewModel();
            using (var db = new SHELEntities())
            {
                var oParametros = db.Catalogo.Find(Convert.ToInt32(Id));
                
                model.Registro_id = oParametros.registro_id;
                model.Catalogo_id = oParametros.catalogo_id;
                model.Nombre = oParametros.nombre;
                model.Descripcion = oParametros.descripcion;
                model.Estado = oParametros.estado;
            }
            return View(model);

        }


        [HttpPost]
        public ActionResult EditarAtributo(EditAtributosCatalogoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new SHELEntities())
            {
                var oParametros = db.Catalogo.Find(model.Registro_id);
                oParametros.catalogo_id = model.Catalogo_id;
                oParametros.nombre= model.Nombre ;
                oParametros.descripcion= model.Descripcion;
                db.Entry(oParametros).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return Redirect(Url.Content("~/Catalogo/"));
        }
        [HttpGet]
        public ActionResult EliminarAtributo(int Id)
        {
            EditAtributosCatalogoViewModel model = new EditAtributosCatalogoViewModel();
            using (var db = new SHELEntities())
            {
                var oParametros = db.Catalogo.Find(Convert.ToInt32(Id));
                model.Catalogo_id = oParametros.catalogo_id;
                model.Registro_id = oParametros.registro_id;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EliminarAtributo(EditAtributosCatalogoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new SHELEntities())
            {
                var oParametros = db.Catalogo.Find(model.Registro_id);               
                oParametros.estado = false;
                db.Entry(oParametros).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return Redirect(Url.Content("~/Catalogo/"));
        }
    }
}