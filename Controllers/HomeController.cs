using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace layout.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List_Products()
        {
            return View();
        }
        public ActionResult Info_Products()
        {
            return View();
        }
        public ActionResult Supports()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult GioHang()
        {
            return View();
        }
        public ActionResult Hangmv()
        {
            return View("List_Products");
        }
        public ActionResult Hanggg()
        {
            return View("List_Products");
        }
        public ActionResult Hangbc()
        {
            return View("List_Products");
        }
        public ActionResult HDMH()
        {
            return View();
        }
        public ActionResult BanDo()
        {
            return View();
        }
        public ActionResult DatHang()
        {
            return View();
        }
    }
}