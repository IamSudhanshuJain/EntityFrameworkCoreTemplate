using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entity;
        private readonly OrganizationContext _context;
        public Repository(OrganizationContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public T Get(long id)
        {
            return _entity.Find(id);
        }
    }
    public interface IRepository<T> where T : class
    {     
        public T Get(long Id);
        
    }
}
