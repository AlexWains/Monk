using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Monk.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SirName { get; set; }
        public string IdCard { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


    }
     
    class WorkerContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
    }
}