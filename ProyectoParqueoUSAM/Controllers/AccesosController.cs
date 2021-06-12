using ProyectoParqueoUSAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ProyectoParqueoUSAM.Controllers 
{ 
    public class AccesosController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        // GET: Accesos

        public ActionResult Ingresar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ingresar(string user, string password)
        {
            try
            {
                using (BD_PARQUEO2Entities bDatos = new BD_PARQUEO2Entities())
                {
                    var usr = (from d in bDatos.USUARIO
                               where d.USUARIO1 == user.Trim() &&
                                     d.PASSWORD == password.Trim() 
                               select d).FirstOrDefault();
                    if (usr == null)
                    {
                        ViewBag.Error = "Password y user No existe";
                        return View();
                    }
                    else
                    {
                        Session["Usuario"] = usr;
                        Session["Usr"] = user;
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

    }
}
