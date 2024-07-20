using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectFile> ProjectFiles { get; set; }
        public DbSet<ProjectJson> ProjectJsons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Primary Key Definitions
            modelBuilder.Entity<Project>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<ProjectFile>().HasKey(pf => pf.Id);
            modelBuilder.Entity<ProjectJson>().HasKey(pj => pj.Id);

            //Relationships
            modelBuilder.Entity<ProjectFile>()
                .HasOne(pf => pf.Project)
                .WithMany(p => p.ProjectFiles)
                .HasForeignKey(pf => pf.ProjectId);

            modelBuilder.Entity<ProjectJson>()
                .HasOne(pj => pj.Project)
                .WithMany(p => p.ProjectJsons)
                .HasForeignKey(pj => pj.ProjectId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Project>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
