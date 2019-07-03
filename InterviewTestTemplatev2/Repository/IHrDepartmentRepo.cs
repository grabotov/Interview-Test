using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InterviewTestTemplatev2.Repository
{
    public interface IHrDepartmentRepo
    {
        Task<IList<HrDepartment>> GetAllDepartments();
        Task<HrDepartment> SelectedDepartmentId(int Id);
        Task<string> GetDepartmentName(int departmentID);
        Task<int> GetDepartmentSumSalary(int departmentID);
    }
}