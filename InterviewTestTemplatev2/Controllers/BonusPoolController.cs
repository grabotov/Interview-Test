﻿using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InterviewTestTemplatev2.Controllers
{
    [HandleError]
    public class BonusPoolController : Controller
    {

        private readonly ICalculationService _calculationService;


        public BonusPoolController(ICalculationService calculationService)
        {

            _calculationService = calculationService;
        }


        // GET: BonusPool
        public async Task<ActionResult> Index()
        {
            try
            {
                var results = await _calculationService.GetAllEmployees();
                if (results != null)
                {
                    return View(results);

                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        //calculation 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> calculate(BonusPoolCalculatorViewModel model)
        {
            try
            {
                var results = await _calculationService.Calculate(model);
                if (results != null)
                {
                    return View(results);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

    }
}