using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Monk.Models
{
    public class Worker
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string IdCard { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }


    class WorkerContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
    }
}