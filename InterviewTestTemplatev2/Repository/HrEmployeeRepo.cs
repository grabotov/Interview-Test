using InterviewTestTemplatev2.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
namespace InterviewTestTemplatev2.Services
{
    public class HrEmployeeRepo : IHrEmployeeRepo
    {
        private readonly MvcInterviewContext _dbContext = new MvcInterviewContext();
        
        public async Task<List<HrEmployee>> GetAllEmployees()
        {
            var calledObject = await _dbContext.HrEmployees.ToListAsync();
            
            return calledObject;
        }

        public async Task<HrEmployee> SelectedEmployeeId(int Id)
        {
            var calledObject = await _dbContext.HrEmployees.FirstOrDefaultAsync(o => o.ID == Id);
            
            return calledObject;
        }


        public async Task<int> GetSumSalary()
        {
            var calledObject = await _dbContext.HrEmployees.SumAsync(sum => sum.Salary);
            return calledObject;
        }
        
        public async Task<List<HrEmployee>> GetDepartmentEmployees(int departmentId)
        {
            var calledObject = await _dbContext.HrEmployees.Where(x => x.HrDepartmentId == departmentId).ToListAsync();
            return calledObject;
        } 

        public void Create(HrEmployee employee)
        {
            _dbContext.HrEmployees.Add(employee);
            _dbContext.Entry(employee).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public void Delete(int employeeID)
        {
            var employee = _dbContext.HrEmployees.Where(x => x.ID == employeeID).FirstOrDefault();
            _dbContext.HrEmployees.Remove(employee);
            _dbContext.Entry(employee).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public void Update(HrEmployee employee)
        { 
            _dbContext.HrEmployees.Attach(employee);
            _dbContext.Entry(employee).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
