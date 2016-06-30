using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Dapper;
using Octopus.WebApp.Models;

namespace Octopus.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Annonces()
        {
            IEnumerable<AnnonceModel> lst;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                lst = conn.Query<AnnonceModel>("SELECT * FROM dbo.Annonces");
            }

            return View(lst);
        }
    }
}