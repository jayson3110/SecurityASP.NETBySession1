using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using SeurityASP.NET.Models;
namespace SeurityASP.NET.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=ASPNETsecurity; integrated security=SSPI");
        public ActionResult Index()
        {

            List<DataList> model = null;
            if(Session["user"] != null)
            {
                int VIPNumber = (int)Session["user"];
                model = GetData(VIPNumber);

            }else
            {
                model = GetData(0);
            }

           

            return View(model);
        }


      







        public List<DataList> GetData(int VIPNUMBER)
        {
            var model = new List<DataList>();
            SqlCommand cmd = new SqlCommand("select * from Datalist WHERE VIP_Number='"+ VIPNUMBER +"'");

            cmd.Connection = con;
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                var datalist = new DataList();
                datalist.Title += sdr["Title"];
                datalist.Picture += sdr["Picture"];
                datalist.VIP_Number += sdr["VIP_Number"].ToString();

                model.Add(datalist);



            }

            return model;

        }




        



    }
}