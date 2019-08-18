using MVCTestingWithDatabase.Models;
using MVCTestingWithDatabase.View.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestingWithDatabase.Controllers
{
    public class ModifyStudentController : Controller
    {
        // GET: ModifyStudent
        public ActionResult Index()
        {
            ModifyStudentViewModel stModel = new ModifyStudentViewModel();
            List<ModifyStudent> st = stModel.GetAllStudent();
            return View(st);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ModifyStudent Mstud, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                ModifyStudentViewModel studentt = new ModifyStudentViewModel();
                studentt.AddStudentData(Mstud,file);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}