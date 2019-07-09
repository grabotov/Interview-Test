using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolEmployeeInDepartmentModel
    {
        public string DepartmentName { get; set; }
        public int DepartmentBonusPoolAllocation { get; set; }
        public string HrEmployee { get; set; }
        public int EmployeeBonusPoolAmount { get; set; }
        public string JobTitle { get; set; }
    }
}