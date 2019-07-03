using InterviewTestTemplatev2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using InterviewTestTemplatev2.Models;

namespace InterviewTestTemplatev2.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentCalculationService _departmentCalculationService;

        public DepartmentController(IDepartmentCalculationService departmentCalculationService)
        {
            _departmentCalculationService = departmentCalculationService;
        }

        // GET: Department
        public async Task<ActionResult> Department()
        {
            try
            {
                var results = await _departmentCalculationService.GetAllDepartments();
                if (results != null)
                {
                    return View(results);
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Calculate(BonusPoolCalculatorViewModel model)
        {
            try
            {

                var table = await _departmentCalculationService.DepartmentEmployeeProcess(model.SelectedDepartmentId, model.BonusPoolAmount);
                //var results = await _departmentCalculationService.Calculate(model.SelectedDepartmentId, model.BonusPoolAmount);
                if (table != null)
                {
                    return View(table);
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}