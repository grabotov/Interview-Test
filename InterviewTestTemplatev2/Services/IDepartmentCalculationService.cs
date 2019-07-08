using InterviewTestTemplatev2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InterviewTestTemplatev2.Services
{
    public interface IDepartmentCalculationService
    {
        Task<BonusPoolCalculatorViewModel> GetAllDepartments();
        //Task<BonusPoolCalculatorResultModel> Calculate(int department, int bonusPoolAmount);
        Task<List<BonusPoolEmployeeInDepartmentModel>> DepartmentEmployeeProcess(int departmentId, int bonusPoolAmount);
    }
}