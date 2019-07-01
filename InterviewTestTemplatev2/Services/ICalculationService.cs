using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTestTemplatev2.Services
{
    public interface ICalculationService 
    {
        //  ActionResult Calculate(BonusPoolCalculatorModel model);
         Task<BonusPoolCalculatorViewModel> GetAllEmployees();

         Task<BonusPoolCalculatorResultModel> Calculate(int employee, int BonusPoolAmount);

    }
}