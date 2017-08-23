using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MrFixIt.Controllers
{
    public class WorkersController : Controller
    {
        private MrFixItContext db = new MrFixItContext();
        //Checks to see if user has a worker profile, if not, redirects user to worker create page
        public IActionResult Index()
        {
            var thisWorker = db.Workers.Include(worker =>worker.Jobs).FirstOrDefault(worker => worker.UserName == User.Identity.Name);
            if (thisWorker != null)
            {
                ViewBag.IncompleteJobs = thisWorker.Jobs.Where(job => !job.Completed);
                ViewBag.CompletedJobs = thisWorker.Jobs.Where(job => job.Completed);

                thisWorker.JobsPending = (thisWorker.JobsClaimed - thisWorker.JobsCompleted);
                db.SaveChanges();
                return View(thisWorker);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        //Connects application user to worker
        [HttpPost]
        public IActionResult Create(Worker worker)
        {
            worker.UserName = User.Identity.Name;
            db.Workers.Add(worker); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkCurrent(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            var thisWorker = db.Workers.FirstOrDefault(worker => worker.UserName == User.Identity.Name);
            thisWorker.Available = false;
            thisJob.Pending = true;
            thisWorker.CurrentJobId = id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkCompleted(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            var thisWorker = db.Workers.FirstOrDefault(worker => worker.UserName == User.Identity.Name);
            thisWorker.Available = true;
            thisJob.Pending = false;
            thisJob.Completed = true;
            thisWorker.CurrentJobId = 0;
            thisWorker.JobsCompleted += 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CompletedJobs()
        {
            var thisWorker = db.Workers.Include(worker => worker.Jobs).FirstOrDefault(worker => worker.UserName == User.Identity.Name);
            ViewBag.AllJobs = thisWorker.Jobs;
            ViewBag.CompletedJobs = thisWorker.Jobs.Where(job => job.Completed);
            return View(thisWorker);
        }
    }
}
