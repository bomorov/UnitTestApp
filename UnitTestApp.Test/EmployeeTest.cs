using Moq;
using UnitTestApp.Controllers;
using UnitTestApp.Interfaces;
using UnitTestApp.Models;
using Xunit;

namespace UnitTestApp.Test
{
    public class EmployeeTest
    {
        #region Property

        public Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();

        #endregion Property

        [Fact]
        public async void GetEmployeebyId()
        {
            mock.Setup(p => p.GetById(1)).ReturnsAsync("JK");
            EmployeesController emp = new EmployeesController(mock.Object);
            string result = await emp.GetEmployeeById(1);
            Assert.Equal("JK", result);
        }

        [Fact]
        public async void GetEmployeeDetails()
        {
            var employeeDTO = new Employee()
            {
                Id = 1,
                Name = "JK",
                Desgination = "SDE"
            };
            mock.Setup(p => p.GetEmployeeDetails(1)).ReturnsAsync(employeeDTO);
            EmployeesController emp = new EmployeesController(mock.Object);
            var result = await emp.GetEmployeeDetails(1);
            Assert.True(employeeDTO.Equals(result));
        }
    }
}