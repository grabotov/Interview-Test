using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InterviewTestTemplatev2.Repository
{
    public class HrDepartmentRepo : IHrDepartmentRepo
    {

        readonly MvcInterviewContext dbContext = new MvcInterviewContext();


        public List<HrDepartment> GetAllDepartments()
        {
            var calledObject =  dbContext.HrDepartments.ToList();
            return calledObject;
        }

        public HrDepartment SelectedDepartmentId(int departmentID)
        {
            var calledObject =  dbContext.HrDepartments.FirstOrDefault(o => o.ID == departmentID);

            return calledObject;
        }
        public string GetDepartmentName(int departmentID)
        {
            var calledObject =  dbContext.HrDepartments.FirstOrDefault(o => o.ID == departmentID);

            return calledObject.Title;
        }
        public int GetDepartmentSumSalary(int departmentID)
        {
            var calledObject =  dbContext.HrEmployees.Where(x => x.HrDepartmentId == departmentID).Sum(sum => sum.Salary);
            return calledObject;
        }
    }
}