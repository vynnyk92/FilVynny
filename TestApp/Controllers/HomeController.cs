using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;
using System.Data.Entity;
using TestApp.Hubs;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        PageContext PageDB = new PageContext();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            var pages = PageDB.Pages.ToList();
            return View(pages);
        }

        [HttpPost]
        public ActionResult AddPage(Page page)
        {
            if (page == null)
            {
                @ViewBag.Result = "Page is Null!";
                return Redirect("Index");
            }
            
            PageDB.Pages.Add(page);
            PageDB.SaveChanges();
            SendMessage("New Page Inserted in the Data Base");
            @ViewBag.Result = "Page Succesfully added!";
            return PartialView("CurrentPage",page);
        }

        private void SendMessage(string message)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            // отправляем сообщение
            context.Clients.All.displayMessage(message);
        }

        [HttpPost]
        public ActionResult LoadPage(int? id)
        {
            Page p1 = null;
            if (id != null && PageDB.Pages.Where(p => p.Id == id) != null)
            {
                p1 = PageDB.Pages.Where(p => p.Id == id).FirstOrDefault();
            }
            
            return Json(p1);
        }
    }
}