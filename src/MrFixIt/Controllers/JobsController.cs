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

        //allows workers to claim jobs
        [HttpPost]
        public IActionResult Claim(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(worker => worker.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index"); ;
        }

        [HttpPost]
        public IActionResult MarkCurrent(int jobId, int workerId)
        {
            Job thisJob = db.Jobs.FirstOrDefault(job => job.JobId == jobId);
            thisJob.Pending = true;
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();

            Worker thisWorker = db.Workers.FirstOrDefault(worker => worker.WorkerId == workerId);
            thisWorker.CurrentJobId = jobId;
            thisWorker.Avaliable = false;
            db.Entry(thisWorker).State = EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkCompleted(int jobId, int workerId)
        {
            Job thisJob = db.Jobs.FirstOrDefault(job => job.JobId == jobId);
            thisJob.Completed = true;
            thisJob.Pending = false;
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();

            Worker thisWorker = db.Workers.FirstOrDefault(worker => worker.WorkerId == workerId);
            thisWorker.CurrentJobId = 0;
            thisWorker.Avaliable = true;
            db.Entry(thisWorker).State = EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
