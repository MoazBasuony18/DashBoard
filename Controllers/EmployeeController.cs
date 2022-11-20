using DashBoard.BL;
using DashBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DashBoard.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee employee;
        private readonly IDepartment department;
        private readonly ICountry country;
        private readonly ICity city;
        private readonly IDistrict district;

        public EmployeeController(IEmployee employee,IDepartment department,ICountry country,ICity city,IDistrict district)
        {
            this.employee = employee;
            this.department = department;
            this.country = country;
            this.city = city;
            this.district = district;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var data = employee.GetAll();
            return View(data);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var data=employee.GetById(id);
            return View(data);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            var data=department.GetAll();
            var countriesData = country.GetAll();
            ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(countriesData, "Id", "CountryName");
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.Add(emp);
                    return RedirectToAction(nameof(Index));
                }
                return View(emp);
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = employee.GetById(id);
            ViewBag.Deptdata = department.GetAll();
            return View(data);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.Update(emp);
                    return RedirectToAction("Index", "Employee");
                }
                var Deptdata = department.GetAll();
                ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", emp.DepartmentId);

                return View(emp);
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = employee.GetById(id);
            return View(data);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult GetCityDataByCountryId(int CntryID)
        {
            var data = city.GetAll().Where(a => a.CountryId == CntryID);
            return Json(data);
        }


        [HttpPost]
        public JsonResult GetDistrictDataByCityId(int cityId)
        {
            var data = district.GetAll().Where(a => a.CityId == cityId);
            return Json(data);
        }
    }
}
