using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ICSApp.IncidentService.Infra.UnitsOfWork
{
    public class FunctionUnitOfWork : IUnitOfWork
    {
        readonly DbContext _dbContext;

        public FunctionUnitOfWork(DbContext dbContext)
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
