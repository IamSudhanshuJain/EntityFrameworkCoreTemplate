using Infrastructure.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDepartmentService
    {
        Department GetDepartment(int i);
        void SaveDepartment(Department department);
        void UpdateDepartment(Department department, int Id);
        void DeleteDepartment(int id);
    }
}
