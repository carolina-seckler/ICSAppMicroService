using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSApp.ActivityService.Application.Interfaces
{
    public interface IRepository
    {
        public T Select<T>(int id) where T : class;
        public void Delete<T>(T entity) where T : class;
        void Insert<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        IQueryable<T> Query<T>() where T : class;
    }
}
