using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monk.Models;
namespace Monk.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        //Get: "/Account/AddWorker?FirstName="+firstName+"&SirName="+sirName+"&IdCard="+idCard+"&Phone="+phone+"&email="+email
        public bool AddWorker(string firstName, string sirName, string idCard, string phone, string email)
        {
            bool added = false;
            bool exsits = false;
            using (var db = new WorkerContext())
            {
                foreach (var item in db.Workers)
                {
                    if(item.IdCard == idCard && item.IdCard != null)
                    {
                        exsits = true;
                    }
                }
                if (!exsits)
                {
                    db.Workers.Add(new Worker { FirstName = firstName, SirName = sirName, IdCard = idCard, Phone = phone, Email = email });
                    db.SaveChanges();
                    added = true;
                }
            }
            return added;

        }
        public ActionResult WorkerAdd()
        {
            return View();
        }
        public ActionResult WorkerTable()
        {
            var db = new WorkerContext();
            return View(db.Workers);
            
        }


        public void DeleteWorker()
        {
            using (var db = new WorkerContext())
            {
                db.Database.Delete();
            }
        }
    }
}