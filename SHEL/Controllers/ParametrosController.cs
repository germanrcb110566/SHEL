using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SHEL.Models;
using SHEL.Models.TableViewModels;
using SHEL.Models.ViewModel;


namespace SHEL.Controllers
{
    public class ParametrosController : Controller
    {
        // GET: Parametros
        public ActionResult Index()
        {
            List<ParametrosTableViewModels> lst = null;
            using (SHELEntities db = new SHELEntities())
            {
                lst = (from d in db.mParametros
                       select new ParametrosTableViewModels
                       {
                           Registro_id = d.registro_id,
                           Smtpserver = d.smtpserver,
                           Smtppuerto = d.smtppuerto,
                           Correo_sistema = d.correo_sistema
                       }).ToList();
            
            }
            return View(lst);
        }


        [HttpGet]
        public ActionResult Grabar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Grabar(ParametrosViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new SHEL.Models.SHELEntities())
            {
                mParametros oParametros = new mParametros
                {
                    smtpserver = model.Smtpserver,
                    smtppuerto = model.Smtppuerto,
                    correo_sistema = model.Correo_sistema,
                    clave_correo = model.Clave_correo
                };

                db.mParametros.Add(oParametros);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/Parametros/"));
        }
        [HttpGet]
        public ActionResult Editar(string Id)
        {
            
            EditParametrosViewModel model = new EditParametrosViewModel();
            using (var db= new SHELEntities())
            {
                var oParametros = db.mParametros.Find(Convert.ToInt32(Id));
                model.Smtpserver = oParametros.smtpserver;
                model.Smtppuerto = oParametros.smtppuerto;
                model.Correo_sistema = oParametros.correo_sistema;
                model.Clave_correo = oParametros.clave_correo;
                model.Registro_id = oParametros.registro_id;
            }
                return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditParametrosViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new SHELEntities())
            {
                var oParametros = db.mParametros.Find(model.Registro_id);
                oParametros.smtpserver = model.Smtpserver;
                oParametros.smtppuerto = model.Smtppuerto;
                oParametros.correo_sistema = model.Correo_sistema;

                if (model.Clave_correo != null && model.Clave_correo.Trim() != "")
                {
                    oParametros.clave_correo = model.Clave_correo;
                }

                db.Entry(oParametros).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
            }


                return Redirect(Url.Content("~/Parametros/"));
        }
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            using (var db = new SHELEntities())
            {
                var oParametros = db.mParametros.Find(Id);
               
                //oParametros.Estado = 0;  //Se Elimina Logicamente El Registro
                db.Entry(oParametros).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();               
            }
            return Content("1");
        }
    }
}