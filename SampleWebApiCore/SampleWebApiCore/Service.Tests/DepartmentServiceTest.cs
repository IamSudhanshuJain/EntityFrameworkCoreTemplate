using Infrastructure;
using Infrastructure.DomainEntities;
using Moq;

namespace Service.Tests
{
    public class DepartmentServiceTest
    {
        private DepartmentService _departmentService;
        private Mock<IRepository<Department>> _repository;
        public DepartmentServiceTest()
        {
            _repository = new Mock<IRepository<Department>>();  
        }


        [Fact]
        public void GetDetails_GivenId_ReturnsDepartment()
        {
            //Arrange
            var department = new Department() { Id = 1, Name = "Engineering" };
            _departmentService = new DepartmentService(_repository.Object);
            _repository.Setup(x=>x.Get(It.IsAny<int>()))
                .Returns(department);

            //Act
            var actual = _departmentService.GetDetails(1);

            //Assert
            Assert.Equal(department.Id, actual.Id);
        }

        [Fact]
        public void GetDetails_GivenIdAsZero_ReturnsNull()
        {
            //Arrange
            Department department = null;
            _departmentService = new DepartmentService(_repository.Object);
            _repository.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(department);

            //Act
            var actual = _departmentService.GetDetails(0);

            //Assert
            Assert.Null(actual);
        }
        [Fact]
        public void SaveInformation_GivenDepartmentAsNull_ThrowsArgumentException()
        {
            //Arrange
            Department department = null;
            _departmentService = new DepartmentService(_repository.Object);

            //Act 
            ArgumentException exception = Assert.Throws<ArgumentException>(() => _departmentService.SaveInformation(department));
            
            //Assert
            Assert.Equal("Department cannot be null", exception.Message);

        }

        [Fact]
        public void UpdateInformation_GivenDepartment_ReturnsUpdatedDepartment()
        {
            //Arrange
            var originalDepartment = new Department() { Id = 1, Name = "Hr Operations" };
            var updateDepartment = new Department() { Id = 1, Name = "Engineering" };

            _departmentService = new DepartmentService(_repository.Object);

            _repository.Setup(x => x.Get(1)).Returns(originalDepartment);
            _repository.Setup(x => x.Update(updateDepartment));

            //Act
            _departmentService.UpdateInformation(updateDepartment, 1);
            var actual = _departmentService.GetDetails(1);

            //Assert
            _repository.Verify(x=>x.Update(originalDepartment),Times.Once);
            Assert.Equal(updateDepartment.Name, actual.Name);
        }
    }
}