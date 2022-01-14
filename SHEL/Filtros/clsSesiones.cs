using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHEL.Controllers;
using SHEL.Models;

namespace SHEL.Filtros
{
        public class clsSesiones : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (HttpContext.Current.Request.RawUrl.ToString() == "/Registro/Persona")
                {
                    //filterContext.HttpContext.Response.Redirect("~/Registro/pCrear");
                }
                else
                {

                    var oUser = (mPersona)HttpContext.Current.Session["identificacion"];

                    if (oUser == null)
                    {
                        if (filterContext.Controller is AccesoController == false)
                        {
                            filterContext.HttpContext.Response.Redirect("/Acceso/Index");
                        }
                    }
                    else
                    {
                        if (filterContext.Controller is AccesoController == true)
                        {
                            filterContext.HttpContext.Response.Redirect("~/Home/Index");
                        }
                    }
                }
                base.OnActionExecuting(filterContext);
            }
        }
    }
    /*if (HttpContext.Current.Request.RawUrl.ToString() == "/Registro")
                    {
                        filterContext.HttpContext.Response.Redirect("~/Registro/Buscar");
                    }
                    else
                    { }*/

    /*else
    {
        if (HttpContext.Current.Request.RawUrl.ToString() == "/Acceso/Registro")
        {
            filterContext.HttpContext.Response.Redirect("~/Acceso/Registro");
        }
        else
        {
            filterContext.HttpContext.Response.Redirect("~/Home/Index");
        }
    }*/