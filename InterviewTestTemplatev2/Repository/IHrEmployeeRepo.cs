﻿using InterviewTestTemplatev2.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTestTemplatev2.Services
{
    public interface IHrEmployeeRepo
    {
        HrEmployee SelectedEmployeeId(int Id);
        int GetSumSalary();
        List<HrEmployee> GetAllEmployees();
        List<HrEmployee> GetDepartmentEmployees(int departmentId);
        void Create(HrEmployee employee);
        void Delete(int employeeID);
        void Update(HrEmployee employee);
    }
}
