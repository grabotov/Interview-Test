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
        List<HrDepartment> GetAllDepartments();
        HrDepartment SelectedDepartmentId(int Id);
        string GetDepartmentName(int departmentID);
        int GetDepartmentSumSalary(int departmentID);
    }
}