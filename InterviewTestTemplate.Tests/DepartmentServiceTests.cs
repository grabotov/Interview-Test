using FluentAssertions;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repository;
using InterviewTestTemplatev2.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestTemplate.Tests
{
    [TestFixture]
    public class DepartmentServiceTests
    {

        private readonly Mock<IHrEmployeeRepo> mockEmployeeRepo = new Mock<IHrEmployeeRepo>();
        private readonly Mock<IHrDepartmentRepo> mockDepartmentRepo = new Mock<IHrDepartmentRepo>();
        private DepartmentCalculationService sut;

        public DepartmentServiceTests()
        {
            sut = new DepartmentCalculationService(mockDepartmentRepo.Object, mockEmployeeRepo.Object);
        }

        [Test]
        public async Task DepartmentService()
        {
            //Arrange
            var departmentID = 3;
            var departmentName = "IT";
            int salarySum = 215000;

            var bonusPoolAmount = 1000;

            List<BonusPoolEmployeeInDepartmentModel> finalResult = new List<BonusPoolEmployeeInDepartmentModel>();
            List<HrEmployee> list = new List<HrEmployee>
            {
                new HrEmployee {
                HrDepartmentId = 3,
                Full_Name = "Sup Reme",
                Salary = 95000,
                JobTitle = "Senior Software Engineer"
                    },
                new HrEmployee {
                HrDepartmentId = 3,
                Full_Name = "James Smith",
                Salary = 25000,
                JobTitle = "Global Integrations Technical Consultant"
                    },
                new HrEmployee {
                HrDepartmentId = 3,
                Full_Name = "George Lucas",
                Salary = 25000,
                JobTitle = "Teacher"
                    },
                new HrEmployee {
                HrDepartmentId = 3,
                Full_Name = "Robie Fowler",
                Salary = 70000,
                JobTitle = "Ex-Footballer"
                    }
            };
            
            mockDepartmentRepo.Setup(repo => repo.GetDepartmentName(departmentID)).Returns(Task.FromResult(departmentName));
            mockDepartmentRepo.Setup(repo => repo.GetDepartmentSumSalary(departmentID)).Returns(Task.FromResult(salarySum));

            mockEmployeeRepo.Setup(repo => repo.GetDepartmentEmployees(departmentID)).Returns(Task.FromResult(list));

            //Act
            var actual = await sut.DepartmentEmployeeProcess(departmentID, bonusPoolAmount);
            var expected = new List<BonusPoolEmployeeInDepartmentModel>();

            //Assert
            actual.Should().NotBeNull();
            actual.Should().BeOfType<List<BonusPoolEmployeeInDepartmentModel>>();
            //create an object and compare with a list of employees in department
            //create an assertion against different properties of the HrEmployeeBonusPool
            


        }
    }
}
