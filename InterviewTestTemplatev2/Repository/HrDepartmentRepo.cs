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


        public async Task<List<HrDepartment>> GetAllDepartments()
        {
            var calledObject = await dbContext.HrDepartments.ToListAsync();
            return calledObject;
        }

        public async Task<HrDepartment> SelectedDepartmentId(int departmentID)
        {
            var calledObject = await dbContext.HrDepartments.FirstOrDefaultAsync(o => o.ID == departmentID);

            return calledObject;
        }
        public async Task<string> GetDepartmentName(int departmentID)
        {
            var calledObject = await dbContext.HrDepartments.FirstOrDefaultAsync(o => o.ID == departmentID);

            return calledObject.Title;
        }
        public async Task<int> GetDepartmentSumSalary(int departmentID)
        {
            var calledObject = await dbContext.HrEmployees.Where(x => x.HrDepartmentId == departmentID).SumAsync(sum => sum.Salary);
            return calledObject;
        }


    }
}