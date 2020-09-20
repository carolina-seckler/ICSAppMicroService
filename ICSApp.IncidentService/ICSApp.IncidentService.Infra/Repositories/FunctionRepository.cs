using ICSApp.IncidentService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ICSApp.IncidentService.Infra.Repositories
{
    public class FunctionRepository : IRepository
    {
        private readonly DbContext _context;

        public FunctionRepository(DbContext context)
        {
            _context = context;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        public void Insert<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>();
        }

        public T Select<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
        }
    }
}
