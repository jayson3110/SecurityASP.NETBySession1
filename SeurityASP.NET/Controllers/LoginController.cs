using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using SeurityASP.NET.Models;

namespace SeurityASP.NET.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=ASPNETsecurity; integrated security=SSPI");
        // GET: Login
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                Response.Redirect("https://www.google.com.vn/imghp?hl=vi");

            }
          
            return View();
        }

        public JsonResult  CheckLogin(FormCollection Collection)
        {
            string uid = Collection["uid"];
            string pwd = Collection["password"];

            JsonResult jr = new JsonResult();

            if(uid=="Admin1" && pwd == "123456")
            {
                Session["user"] = 1;
                Session.Timeout = 5;

                jr.Data = new
                {
                    status = "OK"
                };
            }
            else if(uid == "Admin2" && pwd == "123456")
            {
                Session["user"] = 2;
                Session.Timeout = 5;

                jr.Data = new
                {
                    status = "OK"
                };


            }else
            {
                jr.Data = new
                {
                    status = "False"
                };
            }

            return Json(jr, JsonRequestBehavior.AllowGet);


        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }





    }
}