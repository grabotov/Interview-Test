using NUnit.Framework;
using InterviewTestTemplatev2.Services;
using Moq;
using System.Threading.Tasks;
using FluentAssertions;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(500, 25000, 5000, 2500)]
        [TestCase(500, 0, 5000, 0)]
        [TestCase(500, 250000, 500000, 250)]
        public async Task Test1(int bonusPool, int employeeSalary, int totalSalary, int expectedBonusPoolAllocation)
        {
            //Arrange
            var moq = new Mock<IHrEmployeeRepo>();

            var calcService = new CalculationService(moq.Object);
            var userId = 1;

            var employee = new HrEmployee
            {
                ID = userId,
                Salary = employeeSalary
            };

            moq.Setup(repo => repo.SelectedEmployeeId(userId)).Returns(Task.FromResult(employee));
            moq.Setup(repo => repo.GetSumSalary()).Returns(Task.FromResult(totalSalary));
            //Act
            var result = await calcService.Calculate(userId, bonusPool);

            //Assert
            result.BonusPoolAllocation.Should().Be(expectedBonusPoolAllocation, $"Because the bonus pool {bonusPool} dividied by ");
            result.Should().NotBeNull();
            result.HrEmployee.Should().Be(employee);

        }


        [Test]
        public async Task ControllerTest()
        {

            //arrange
            var userId = 1;
            int bonuspool = 100;
            int totalSalary = 5000;
            var employee = new HrEmployee
            {
                ID = userId,
            };

            //act
            var moq = new Mock<IHrEmployeeRepo>();
            moq.Setup(repo => repo.SelectedEmployeeId(userId)).Returns(Task.FromResult(employee));
            moq.Setup(repo => repo.GetSumSalary()).Returns(Task.FromResult(totalSalary));

            var calcService = new CalculationService(moq.Object);
            var result = await calcService.Calculate(userId, bonuspool);
            //assert
            result.Should().NotBeNull();
            result.Should().BeOfType<BonusPoolCalculatorResultModel>();
        }
    }
}