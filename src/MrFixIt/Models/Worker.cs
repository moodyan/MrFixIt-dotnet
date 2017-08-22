using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MrFixIt.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Available { get; set; }
        //username comes from Identity.User
        public string UserName { get; set; }
        public int CurrentJobId { get; set; }
        public int JobsClaimed { get; set; }
        public int JobsCompleted { get; set; }
        public int JobsPending { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }

        public Worker()
        {
            Available = true;
        }

    }
}