using ICSApp.ActivityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.ActivityService.Infra.Context
{
    public partial class ActivityDbContext : DbContext
    {
        public ActivityDbContext() { }
        public ActivityDbContext(DbContextOptions<ActivityDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Incident { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification.Notification>();

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.IdActivity);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DateOpen).HasColumnType("datetime").IsRequired();

                entity.Property(e => e.DateClosed).HasColumnType("datetime");

                entity.Property(e => e.IdActivity).IsRequired();

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .IsRequired();

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.IdSection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .IsRequired();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.IdSection);

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
