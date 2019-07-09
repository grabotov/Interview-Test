using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InterviewTestTemplatev2.Services
{
    public class DepartmentCalculationService : IDepartmentCalculationService
    {
        private readonly IHrDepartmentRepo _hrDepartmentRepo;
        private readonly IHrEmployeeRepo _hrEmployeeRepo;
        private bool _disposed;

        public DepartmentCalculationService(IHrDepartmentRepo hrDepartmentRepo, IHrEmployeeRepo hrEmployeeRepo)
        {
            _hrDepartmentRepo = hrDepartmentRepo;
            _hrEmployeeRepo = hrEmployeeRepo;
        }

        // GET: BonusPool
        public async Task<BonusPoolCalculatorViewModel> GetAllDepartments()
        {
            var viewModelList =  _hrDepartmentRepo.GetAllDepartments();
            var viewModel = MapEntitiesToViewModel(viewModelList);
            return viewModel;
        }

        private BonusPoolCalculatorViewModel MapEntitiesToViewModel(List<HrDepartment> departments)
        {
            var model = new BonusPoolCalculatorViewModel
            {
                AllDepartments = departments
            };
            return model;
        }

        //REMOVED CODE AS I DECIDED TO WORK IT THROUGH DIFFERENT WAY

        // All the calculation calls method.
        //public async Task<BonusPoolCalculatorResultModel> Calculate(int departmentId, int bonusPoolAmount)
        //{
        //    HrDepartment hrDepartment = await _hrDepartmentRepo.SelectedDepartmentId(departmentId);
            
        //    int allocatedPercentage = Convert.ToInt32(hrDepartment.BonusPoolAllocationPerc);
        //    decimal bonusAllocation = CalculateDepartmentBonus(allocatedPercentage, bonusPoolAmount);
        //    var result = ChangeType(hrDepartment, Convert.ToInt32(bonusAllocation));
        //    return result;
        //}
        //CALCULATE THE AMOUNT
        //private decimal CalculateDepartmentBonus(decimal allocatedPercentage, int bonusPoolAmount)
        //{
        //    decimal result = (decimal)(allocatedPercentage / 100) * bonusPoolAmount;
        //    return result;
        //}

        //CREATE A VAR THAT HOLDS 2 VALUES
        //private BonusPoolCalculatorResultModel ChangeType(HrDepartment department, int bonusAllocation)
        //{
        //    var result = new BonusPoolCalculatorResultModel();
        //    result.HrDepartment = department;
        //    result.BonusPoolAllocation = bonusAllocation;
        //    return result;
        //}

        public async Task<IEnumerable<BonusPoolEmployeeInDepartmentModel>> DepartmentEmployeeProcess(int departmentId, int bonusPoolAmount)
        {
            string departmentName =  _hrDepartmentRepo.GetDepartmentName(departmentId);
            //get employee list
            var departmentEmployeeList = await GetDepartmentEmployees(departmentId);
            //get DepartmentSalarySum
            int departmentSalarySum = departmentEmployeeList.Sum(e => e.Salary);
            //Calculation method
            var result =  EmployeeDepartmentCalculate(departmentEmployeeList, departmentSalarySum, bonusPoolAmount, departmentName);

            //return the List
            return result;
        }

        private async Task<List<HrEmployee>> GetDepartmentEmployees (int departmentId)
        {
            var result =  _hrEmployeeRepo.GetDepartmentEmployees(departmentId);
            return result;
        }

        private IEnumerable<BonusPoolEmployeeInDepartmentModel> EmployeeDepartmentCalculate(List<HrEmployee> departmentEmployeeList, int departmentSalarySum, int bonusPoolAmount, string departmentName)
        {
            foreach (HrEmployee employee in departmentEmployeeList)
            {
                decimal employeeSalaryAllocation = CalculateSalaryPerEmployee(employee.Salary, departmentSalarySum, bonusPoolAmount);
                yield return new BonusPoolEmployeeInDepartmentModel
                {
                    DepartmentName = departmentName,
                    DepartmentBonusPoolAllocation = bonusPoolAmount,
                    HrEmployee = employee.Full_Name,
                    EmployeeBonusPoolAmount = Convert.ToInt32(employeeSalaryAllocation),
                    JobTitle = employee.JobTitle
                };
            }
        }

        private static decimal CalculateSalaryPerEmployee(int employeeSalary, int departmentSalarySum, int bonusPoolAmount)
        {
            decimal bonusPoolAmountForEmployee = ((decimal)employeeSalary / (decimal)departmentSalarySum) * (decimal)bonusPoolAmount;
            return bonusPoolAmountForEmployee;
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