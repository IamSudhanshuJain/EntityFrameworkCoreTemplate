using Infrastructure;
using Infrastructure.DomainEntities;
using System;

namespace Service
{
    public class DepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }

        public Department GetDetails()
        {
            return _departmentRepository.Get(1);
        }
    }
}
