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
        private readonly IHrEmployeeRepo _hrEmployeeRepo;
        private readonly IHrDepartmentRepo _hrDepartmentRepo;
        public HrEmployeesController(IHrEmployeeRepo hrEmployeeRepo, IHrDepartmentRepo hrDepartmentRepo)
        {
            _hrEmployeeRepo = hrEmployeeRepo;
            _hrDepartmentRepo = hrDepartmentRepo;
        }

        // GET: HrEmployees
        public async Task<ActionResult> Index()
        {
            var employees = await _hrEmployeeRepo.GetAllEmployees();
            return View(employees);
        }

        // GET: HrEmployees/Details/5
        public async Task<ActionResult> Details(int id)
        {
            
            var hrEmployee = await _hrEmployeeRepo.SelectedEmployeeId(id);
            if (hrEmployee == null)
            {
                return HttpNotFound();
            }
            return View(hrEmployee);
        }

        // GET: HrEmployees/Create
        public ActionResult Create()
        {
            return View();
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
                 _hrEmployeeRepo.Create(hrEmployee);
                return RedirectToAction("Index");
            }

            return View(hrEmployee);
        }

        // GET: HrEmployees/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
           
                HrEmployee hrEmployee = await _hrEmployeeRepo.SelectedEmployeeId(id);
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
                _hrEmployeeRepo.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: HrEmployees/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HrEmployee hrEmployee = await _hrEmployeeRepo.SelectedEmployeeId(id);
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
             _hrEmployeeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
