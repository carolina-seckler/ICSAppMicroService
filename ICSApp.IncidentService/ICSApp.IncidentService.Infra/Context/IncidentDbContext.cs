using ICSApp.IncidentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ICSApp.IncidentService.Infra.Context
{
    public partial class IncidentDbContext : DbContext
    {
        public IncidentDbContext() { }

        public IncidentDbContext(DbContextOptions<IncidentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Incident> Incident { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification.Notification>();

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.HasKey(e => e.IdIncident);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IncidentDate).HasColumnType("datetime");

            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.IdMember);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Incident)
                   .WithMany(p => p.Members)
                   .HasForeignKey(d => d.IdIncident)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .IsRequired();

                entity.HasOne(d => d.Function)
                   .WithMany(p => p.Members)
                   .HasForeignKey(d => d.IdFunction)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .IsRequired();

            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.HasKey(e => e.IdFunction);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
