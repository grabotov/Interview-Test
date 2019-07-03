using System.Collections.Generic;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolCalculatorViewModel
    {

        public int BonusPoolAmount { get; set; }
        public IList<Data.HrEmployee> AllEmployees { get; set; }        
        public int SelectedEmployeeId { get; set; }
        public int SelectedDepartmentId { get; set; }
        
        public IList<Data.HrDepartment> AllDepartments { get; set; }
    }
}