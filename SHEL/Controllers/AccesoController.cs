using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHEL.Models;

namespace SHEL.Controllers
{
    public class AccesoController : Controller
    {
 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Persona(string identificacion, string password)
        {
            try
            {
                using (SHELEntity db = new SHELEntity())
                {
                    var lst = from d in db.mPersona
                              where d.identificacion == identificacion && d.clave == password && d.estado == true
                              select d;
                    if (lst.Count() > 0)
                    {
                        mPersona oUser = lst.First();
                        Session["identificacion"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario o Clave invalido");
                    }
                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un Error" + ex.Message);
            }


        }
        public ActionResult Cerrar()
        {
            Session["identificacion"] = null;
            return View();
        }
    }
}