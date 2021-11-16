using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Impl
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbSet<T> _set;
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public void Create(T item)
        {
            _set.Add(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            _set.Remove(item);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate, int pageNumber = 0, int pageSize = 10)
        {
            return _set.Where(predicate).Skip(pageSize * pageNumber).Take(pageNumber).ToList();
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _set.ToList();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
