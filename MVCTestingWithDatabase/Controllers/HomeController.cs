using MVCTestingWithDatabase.Models;
using MVCTestingWithDatabase.View.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestingWithDatabase.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            StudentViewModel stModel = new StudentViewModel();
            List<Student> st = stModel.GetAllStudent();
            return View(st);
        }

        public ActionResult Create()
        {
       
            return View();
        }

        [HttpPost]
        public ActionResult Create( Student stud)
        {
            if (ModelState.IsValid)
            {
                StudentViewModel studentt = new StudentViewModel();
                studentt.AddStudentData(stud);
               return RedirectToAction("Index");
            }
            

            return View();
        }

        public ActionResult Details(int id)
        {
            StudentViewModel stModel = new StudentViewModel();
            Student st = stModel.GetAllStudentDetailsById(id);
            return View(st);
        }

        public ActionResult Edit(int id)
        {
            StudentViewModel stModel = new StudentViewModel();
            Student st = stModel.GetAllStudentDetailsById(id);
            return View(st);
        }

        [HttpPost]
        public ActionResult Edit(Student stud)
        {
            if (ModelState.IsValid)
            {
                StudentViewModel studentt = new StudentViewModel();
                studentt.EditStudentData(stud);
                return RedirectToAction("Index");
            }


            return View();
        }

        public ActionResult Delete(int id)
        {
                StudentViewModel studentt = new StudentViewModel();
                studentt.DeleteStudentById(id);
                return RedirectToAction("Index");
        }
    }
}