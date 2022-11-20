using DashBoard.BL;
using DashBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment department;

        public DepartmentController(IDepartment department)
        {
            this.department = department;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var data=department.GetAll();
            return View(data);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Add(dpt);
                    return RedirectToAction(nameof(Index));
                }
                return View(dpt) ;
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Update(dpt);
                    return RedirectToAction("Index", "Department");
                }
                return View(dpt);
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                    department.Delete(id);
                    return RedirectToAction(nameof(Index));     
            }
            catch
            {
                return View();
            }
        }
    }
}
