using ICSApp.ActivityService.Application.Interfaces;
using ICSApp.ActivityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSApp.ActivityService.Infra.UnitsOfWork
{
    public class SectionUnitOfWork : IUnitOfWork
    {
        readonly DbContext _dbContext;

        public SectionUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            var user_name = "user";

            var entries = _dbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Where(e => e.Entity is IAuditable);

            //Insert
            foreach (var item in entries.Where(e => e.State == EntityState.Added).Select(e => (IAuditable)e.Entity))
            {
                item.DataHoraInsercao = DateTime.Now;
                item.UsuarioInsercao = user_name;
            }

            //Update
            foreach (var item in entries.Where(e => e.State == EntityState.Modified).Select(e => (IAuditable)e.Entity))
            {
                item.DataHoraUltimaAtualizacao = DateTime.Now;
                item.UsuarioUltimaAtualizacao = user_name;
            }

            _dbContext.SaveChanges();
        }
    }
}
