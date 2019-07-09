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
        
        public List<HrEmployee> GetAllEmployees()
        {
            var calledObject =  _dbContext.HrEmployees.ToList();
            
            return calledObject;
        }

        public HrEmployee SelectedEmployeeId(int Id)
        {
            var calledObject =  _dbContext.HrEmployees.FirstOrDefault(o => o.ID == Id);
            
            return calledObject;
        }


        public int GetSumSalary()
        {
            var calledObject =  _dbContext.HrEmployees.Sum(sum => sum.Salary);
            return calledObject;
        }
        
        public List<HrEmployee> GetDepartmentEmployees(int departmentId)
        {
            var calledObject =  _dbContext.HrEmployees.Where(x => x.HrDepartmentId == departmentId).ToList();
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
