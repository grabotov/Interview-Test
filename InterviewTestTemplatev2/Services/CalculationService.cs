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

        public async Task<BonusPoolCalculatorResultModel> Calculate(int employee,int BonusPoolAmount)
        {
            // Result model
            HrEmployee hrEmployee = await _hrEmployeeRepo.SelectedEmployeeId(employee);
            int salary = hrEmployee.Salary;
            //Calc %
            decimal bonusPercentage = await CalculateEmployeePercentage(BonusPoolAmount, salary);
            // Calc bonus
            int bonusAllocation = CalculateBonusAllocation(bonusPercentage, BonusPoolAmount);
            //stick all in 1 var
            var result =  ChangeType(hrEmployee, bonusAllocation);

            return result;
        }



        private async Task<decimal> CalculateEmployeePercentage(int totalAmount, int salary)
        {

            //get the total salary budget for the company
            int totalSalary = await _hrEmployeeRepo.GetSumSalary();

            //calculate the bonus percentage for the employee
            decimal bonusPercentage = salary / (decimal)totalSalary;

            return bonusPercentage;
        }

        private int CalculateBonusAllocation(decimal bonusPercentage, int totalBonusPool)
        {
            int bonusAllocation = (int)(bonusPercentage * totalBonusPool);
            return bonusAllocation;
        }

        private BonusPoolCalculatorResultModel ChangeType(HrEmployee employee, int bonusAllocation)
        {
            var result = new BonusPoolCalculatorResultModel();
            result.HrEmployee = employee;
            result.BonusPoolAllocation = bonusAllocation;
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