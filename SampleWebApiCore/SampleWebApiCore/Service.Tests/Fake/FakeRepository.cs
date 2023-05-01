using Infrastructure;
using Infrastructure.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests.Fake
{
    public class FakeRepository : IRepository<Department>
    {
        public List<Department> departmentContext;
        public FakeRepository()
        {
            departmentContext= new List<Department>();
        }
        public void Delete(Department data)
        {
            departmentContext.Remove(data);
        }

        public Department Get(object Id)
        {
            return departmentContext.Find(x => x.Id == (int)Id);
        }

        public void Save(Department Data)
        {
            departmentContext.Add(Data);
        }

        public void Update(Department Data)
        {
            var department = departmentContext.Find(x => x.Id == Data.Id);
            if(department !=null)
            {
                departmentContext.Remove(department);

                    department.Name = Data.Name;
                    department.Description = Data.Description;  
                    department.Id = Data.Id;

                departmentContext.Add(department);
            }
        }
    }
}
