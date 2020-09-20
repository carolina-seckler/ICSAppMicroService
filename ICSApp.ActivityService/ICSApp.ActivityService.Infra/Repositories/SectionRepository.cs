﻿using ICSApp.ActivityService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSApp.ActivityService.Infra.Repositories
{
    public class SectionRepository : IRepository
    {
        private readonly DbContext _context;

        public SectionRepository(DbContext context)
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
