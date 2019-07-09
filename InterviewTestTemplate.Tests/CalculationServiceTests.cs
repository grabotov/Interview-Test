using NUnit.Framework;
using InterviewTestTemplatev2.Services;
using Moq;
using System.Threading.Tasks;
using FluentAssertions;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repository;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private readonly Mock<IHrEmployeeRepo> mockEmployeeRepo = new Mock<IHrEmployeeRepo>();
        private CalculationService sut;

        [SetUp]
        public void Setup()
        {
            sut = new CalculationService(mockEmployeeRepo.Object);
        }

        [TestCase(500, 25000, 5000, 2500)]
        [TestCase(500, 0, 5000, 0)]
        [TestCase(500, 250000, 500000, 250)]
        public async Task Test1(int bonusPool, int employeeSalary, int totalSalary, int expectedBonusPoolAllocation)
        {
            //Arrange
            var userId = 1;

            var employee = new HrEmployee
            {
                ID = userId,
                Salary = employeeSalary
            };

            mockEmployeeRepo.Setup(repo => repo.SelectedEmployeeId(userId)).Returns(employee);
            mockEmployeeRepo.Setup(repo => repo.GetSumSalary()).Returns(totalSalary);
            
            //Act
            var result = await sut.Calculate(userId, bonusPool);

            //Assert
            result.BonusPoolAllocation.Should().Be(expectedBonusPoolAllocation, $"Because the bonus pool {bonusPool} dividied by ");
            result.Should().NotBeNull();
            result.HrEmployee.Should().Be(employee);

        }
        
        [Test]
        public async Task ControllerTest()
        {
            //Arrange
            var userId = 1;
            int bonuspool = 1000;
            int totalSalary = 5000;
            var employee = new HrEmployee
            {
                ID = userId,
                Salary = totalSalary
            };

            
            mockEmployeeRepo.Setup(repo => repo.SelectedEmployeeId(userId)).Returns(employee);
            mockEmployeeRepo.Setup(repo => repo.GetSumSalary()).Returns(totalSalary);

            //Act
            var result = await sut.Calculate(userId, bonuspool);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<BonusPoolCalculatorResultModel>();
        }
    }
}