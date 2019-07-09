using InterviewTestTemplatev2.Data;
using System.Collections.Generic;

namespace InterviewTestTemplatev2.Services
{
    public interface IHrEmployeeService
    {
        List<HrEmployee> GetAllEmployees();
        void Create(HrEmployee employee);
        void Update(HrEmployee employee);
        void Delete(int employeeId);
        HrEmployee SelectedEmployeeId(int employeeId);
        List<HrDepartment> GetAllDepartments();
    }
}
