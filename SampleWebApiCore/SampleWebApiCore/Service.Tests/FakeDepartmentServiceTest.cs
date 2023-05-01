using Infrastructure;
using Infrastructure.DomainEntities;
using Service.Tests.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    public class FakeDepartmentServiceTest
    {
        private IDepartmentService _service;
        private IRepository<Department> _repository;

        public FakeDepartmentServiceTest()
        {
            _repository = new FakeRepository();
            _service = new DepartmentService(_repository);
        }


        [Fact]
        public void GetDetails_GivenId_ReturnsDepartment()
        {
            //Arrange
            Department department = new Department() { Id = 1, Name = "Engineering" };
            _repository.Save(department);
            department = new Department() { Id = 2, Name = "Hr Operations" };
            _repository.Save(department);
            department = new Department() { Id = 3, Name = "Sales and Marketing" };
            _repository.Save(department);

            //Act
                var actual = _service.GetDetails(1);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal("Engineering", actual.Name);

        }


    }
}
