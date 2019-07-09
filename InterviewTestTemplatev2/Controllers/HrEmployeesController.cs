using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Services;
using InterviewTestTemplatev2.Repository;

namespace InterviewTestTemplatev2.Controllers
{
    public class HrEmployeesController : Controller
    {
        private readonly IHrEmployeeService _hrEmployeeService;

        public HrEmployeesController(IHrEmployeeService hrEmployeeService)
        {
            _hrEmployeeService = hrEmployeeService;
        }

        // GET: HrEmployees
        public async Task<ActionResult> Index()
        {
            // call service now
            var employees = _hrEmployeeService.GetAllEmployees();
            return View(employees);
        }

        // GET: HrEmployees/Details/5
        public ActionResult Details(int id)
        {
            
            var hrEmployee =   _hrEmployeeService.SelectedEmployeeId(id);
            if (hrEmployee == null)
            {
                return HttpNotFound();
            }
            return View(hrEmployee);
        }

        // GET: HrEmployees/Create
        public ActionResult Create()
        {
            var originalModel = new Models.HrEmployees();
            originalModel.AllDepartments =  _hrEmployeeService.GetAllDepartments();
            return View(originalModel);
        }

        // POST: HrEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HrEmployee hrEmployee)
        {
            if (ModelState.IsValid)
            {
                 _hrEmployeeService.Create(hrEmployee);
                return RedirectToAction("Index");
            }

            return View(hrEmployee);
        }

        // GET: HrEmployees/Edit/5
        public ActionResult Edit(int id)
        {
           
                HrEmployee hrEmployee =  _hrEmployeeService.SelectedEmployeeId(id);
                if (hrEmployee == null)
                {
                    return HttpNotFound();
                }
                return View(hrEmployee);
            }

        

        // POST: HrEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HrEmployee employee)
        {
            if (ModelState.IsValid)
            {
                _hrEmployeeService.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: HrEmployees/Delete/5
        public ActionResult Delete(int id)
        {
            HrEmployee hrEmployee =  _hrEmployeeService.SelectedEmployeeId(id);
            if (hrEmployee == null)
            {
                return HttpNotFound();
            }
            return View(hrEmployee);
        }

        // POST: HrEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             _hrEmployeeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
