using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSApp.IncidentService.Infra.UnitsOfWork
{
    public class MemberUnitOfWork : IUnitOfWork
    {
        readonly DbContext _dbContext;

        public MemberUnitOfWork(DbContext dbContext)
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
