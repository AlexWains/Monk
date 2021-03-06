﻿using System;
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
        public bool AddWorker(string firstName, string surname, string idCard, string phone, string email)
        {
            bool added = false;
            bool exsits = false;
            using (var db = new WorkerContext())
            {
                foreach (var item in db.Workers)
                {
                    if(item.IdCard == idCard)
                    {
                        exsits = true;
                    }
                }
                if (!exsits && idCard != "")
                {
                    db.Workers.Add(new Worker { FirstName = firstName, Surname = surname, IdCard = idCard, Phone = phone, Email = email , Username = idCard, Password = phone});
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

        public void DeleteWorkerDB()
        {
            using (var db = new WorkerContext())
            {
                db.Database.Delete();
            }
        }


        public bool ChangePasswordAct(string username, string oldPassword, string newPassword)
        {
            bool Success = false;
            using (var db = new WorkerContext())
            {
                Worker user = db.Workers.SingleOrDefault(x => x.Username == username);
                if (user!=null && user.Password == oldPassword)
                {
                    user.Password = newPassword;
                    db.Workers.Attach(user);
                    db.SaveChanges();
                    Success = true;
                }
            }
            return Success;
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}