using curdApplication_Without_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace curdApplication_Without_Entity_Framework.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            StudentDBContext db = new StudentDBContext();
            List<ClsStudentscs> obj = db.GetStudents();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();

        }

            [HttpPost]
        public ActionResult Create(ClsStudentscs obj)
        {


            try {
                if (ModelState.IsValid == true)
                {
                    StudentDBContext context = new StudentDBContext();
                    bool check = context.AddStudents(obj);

                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data Has Been Inserted SucessFully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();

            }
            catch
            {
                return View();
            }



    



        }


        public ActionResult Edit(int id)
        {
            StudentDBContext context = new StudentDBContext();
            var row = context.GetStudents().Find(model => model.id == id);
            

            return View(row);
        }

        public ActionResult Delete(int id)
        {
            StudentDBContext context = new StudentDBContext();
            var row = context.GetStudents().Find(model => model.id == id);


            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id,ClsStudentscs obj)
        {
            if (ModelState.IsValid == true)
            {
                StudentDBContext context = new StudentDBContext();
                bool check = context.UpdatestudentDetail(obj);

                if (check == true)
                {
                    TempData["UpdateMassage"] = "Data Has Been Updated SucessFully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id,ClsStudentscs obj)
        {
            StudentDBContext context = new StudentDBContext();
            bool check = context.DeletestudentDetail(id);

            if (check == true)
            {
                TempData["DeleteDetail"] = "Data Has Been Deleted SucessFully";
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}