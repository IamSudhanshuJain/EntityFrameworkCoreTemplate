using Infrastructure.DomainEntities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SampleWebApiCore.Controllers;
using SampleWebApiCore.Models;
using Service;

namespace Controller.Tests
{
    public class DepartmentControllerTest
    {
        private readonly Mock<IDepartmentService> _departmentService;
        private readonly DepartmentController _controller;
        public DepartmentControllerTest()
        {
            _departmentService = new Mock<IDepartmentService>();
            _controller = new DepartmentController(null, _departmentService.Object);
        }
        [Fact]
        public void Get_GivenDepartmentId_ReturnDepartment()
        {
            //Arrange
            var department = new Department() { Id = 1, Name = "Engineering" };
            _departmentService.Setup(x => x.GetDetails(It.IsAny<int>()))
                .Returns(department);

            //Act
            var actual = (ObjectResult)_controller.Get(1);
            Department actualDepartment = actual.Value as Department;

            //Assert
            Assert.IsAssignableFrom<IActionResult>(actual);
            Assert.NotNull(actual);
            Assert.Equal(department.Id, actualDepartment.Id);
        }

        [Fact]
        public void SaveDepartment_GivenEmptyDepartment_ReturnBadRequest()
        {
            //Arrange
            var department = new DepartmentRequest() { };
            _controller.ModelState.AddModelError("Name", "The Name field is required");

            //Act
            ObjectResult actual = (ObjectResult)_controller.SaveData(department);

            //Assert
            Assert.IsType<BadRequestObjectResult>(actual);
            Assert.Equal(400, actual.StatusCode);
        }
    }
}