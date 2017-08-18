using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();
        
        public IActionResult Index()
        {
            ViewBag.Worker = db.Workers.FirstOrDefault(worker => worker.UserName == User.Identity.Name);
            return View(db.Jobs.Include(job => job.Worker).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Claim(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            return View(thisJob);
        }
        //allows workers to claim jobs - in HTML, change to if statement that only users with a worker profile can claim a job
        //TODO: add method to change worker.available=false and job.pending=true when job is claimed 
        //[HttpPost]
        //public IActionResult Claim(Job job)
        //{
        //    job.Worker = db.Workers.FirstOrDefault(worker => worker.UserName == User.Identity.Name);
        //    //job.Worker.Avaliable = false;
        //    //job.Pending = true;
        //    db.Entry(job).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult Claim(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(worker => worker.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index"); ;
        }
    }
}
