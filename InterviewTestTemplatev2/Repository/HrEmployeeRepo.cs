using InterviewTestTemplatev2.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
namespace InterviewTestTemplatev2.Services
{
    public class HrEmployeeRepo : IHrEmployeeRepo
    {
        private readonly MvcInterviewContext dbContext = new MvcInterviewContext();

        public async Task<List<HrEmployee>> GetAllEmployees()
        {
            var calledObject = await dbContext.HrEmployees.ToListAsync();
            
            return calledObject;
        }

        public async Task<HrEmployee> SelectedEmployeeId(int Id)
        {
            var calledObject = await dbContext.HrEmployees.FirstOrDefaultAsync(o => o.ID == Id);
            
            return calledObject;
        }


        public async Task<int> GetSumSalary()
        {
            var calledObject = await dbContext.HrEmployees.SumAsync(sum => sum.Salary);
            return calledObject;
        }
        
        public async Task<List<HrEmployee>> GetDepartmentEmployees(int departmentId)
        {
            var calledObject = await dbContext.HrEmployees.Where(x => x.HrDepartmentId == departmentId).ToListAsync();
            return calledObject;
        } 

    }
}