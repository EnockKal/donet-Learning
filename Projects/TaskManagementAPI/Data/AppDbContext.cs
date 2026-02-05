using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models.Entities;

namespace TaskManagementAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Models.Entities.TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.ProjectName)
                .IsRequired();

                entity.HasMany(p => p.TaskItems)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Models.Entities.TaskItem>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title)
                .IsRequired();

                entity.HasOne(t => t.User)
                .WithMany(u => u.TaskItems)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
