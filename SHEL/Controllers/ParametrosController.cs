using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SHEL.Models.ViewModel;
using SHEL.Models;

namespace SHEL.Controllers
{
    public class ParametrosController : Controller
    {
        // GET: Parametros
        public ActionResult Index()
        {
            List<ParametrosViewModel> lst = null;
            using (SHELEntities db = new SHELEntities())
            {
                lst = (from d in db.mParametros
                       select new ParametrosViewModel
                       {
                           smtpserver = d.smtpserver,
                           smtppuerto = d.smtppuerto,
                           correo_sistema = d.correo_sistema
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
                mParametros oParametros = new mParametros();
                oParametros.smtpserver = model.smtpserver;
                oParametros.smtppuerto = model.smtppuerto;
                oParametros.correo_sistema = model.correo_sistema;
                oParametros.clave_correo = model.clave_correo;

                db.mParametros.Add(oParametros);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/Parametros"));
        }
    }
}