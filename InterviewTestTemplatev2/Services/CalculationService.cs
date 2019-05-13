using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTestTemplatev2.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IHrEmployeeRepo _hrEmployeeRepo;
        private bool _disposed;

        public CalculationService(IHrEmployeeRepo hrEmployeeRepo)
        {
            _hrEmployeeRepo = hrEmployeeRepo;
        }

        // GET: BonusPool
        public async Task<BonusPoolCalculatorViewModel> GetAllEmployees()
        {
            var viewModelList = await _hrEmployeeRepo.GetAllEmployees();
            var viewModel = MapEntitiesToViewModel(viewModelList);
            
            return viewModel;
        }

        private BonusPoolCalculatorViewModel MapEntitiesToViewModel(IList<HrEmployee> employees)
        {
            var model = new BonusPoolCalculatorViewModel
                {
                    AllEmployees = employees
                };

            return model;
        }

        public async Task<BonusPoolCalculatorResultModel> Calculate(BonusPoolCalculatorViewModel poolAmount)
        {
            int selectedEmployeeId = poolAmount.SelectedEmployeeId;
            int totalBonusPool = poolAmount.BonusPoolAmount;

            //load the details of the selected employee using the ID
            HrEmployee hrEmployee = await _hrEmployeeRepo.SelectedEmployeeId(selectedEmployeeId);

            int employeeSalary = hrEmployee.Salary;

            //get the total salary budget for the company
            int totalSalary = await _hrEmployeeRepo.GetSumSalary();
            
            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employeeSalary / (decimal)totalSalary;
            int bonusAllocation = (int)(bonusPercentage * totalBonusPool);

            BonusPoolCalculatorResultModel result = new BonusPoolCalculatorResultModel();
            result.hrEmployee = hrEmployee;
            result.bonusPoolAllocation = bonusAllocation;
            return result;
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}