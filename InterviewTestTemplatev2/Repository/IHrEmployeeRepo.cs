using InterviewTestTemplatev2.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTestTemplatev2.Services
{
    public interface IHrEmployeeRepo
    {
        Task<HrEmployee> SelectedEmployeeId(int Id);
        Task<int> GetSumSalary();
        Task<List<HrEmployee>> GetAllEmployees();
        Task<List<HrEmployee>> GetDepartmentEmployees(int departmentId);
    }
}
