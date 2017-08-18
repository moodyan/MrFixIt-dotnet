using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;

namespace MrFixIt.Controllers
{
    public class HomeController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var thisWorker = db.Workers.FirstOrDefault(worker => worker.UserName == User.Identity.Name);
                return View(thisWorker);
            } else
            {
                return View();
            }
        }
    }
}
