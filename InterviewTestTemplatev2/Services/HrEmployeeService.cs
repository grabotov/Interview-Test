using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Services
{
    public class HrEmployeeService : IHrEmployeeService
    {

        private readonly IHrEmployeeRepo _hrEmployeeRepo;
        private readonly IHrDepartmentRepo _hrDepartmentRepo;


        public HrEmployeeService(IHrEmployeeRepo hrEmployeeRepo, IHrDepartmentRepo hrDepartmentRepo)
        {
            _hrEmployeeRepo = hrEmployeeRepo;
            _hrDepartmentRepo = hrDepartmentRepo;
        }

        public List<HrEmployee> GetAllEmployees()
        {
            var employees =  _hrEmployeeRepo.GetAllEmployees();
            return employees;
        }

        public List<HrDepartment> GetAllDepartments()
        {
            var departments = _hrDepartmentRepo.GetAllDepartments();
            return departments;
        }

        public HrEmployee SelectedEmployeeId(int employeeId)
        {
           var employee = _hrEmployeeRepo.SelectedEmployeeId(employeeId);
            return employee;
        }

        public void Create(HrEmployee employee)
        {
            _hrEmployeeRepo.Create(employee);
        }

        public void Update(HrEmployee employee)
        {
            _hrEmployeeRepo.Update(employee);
        }

        public void Delete (int employeeId)
        {
            _hrEmployeeRepo.Delete(employeeId);
        }
        
    }
}