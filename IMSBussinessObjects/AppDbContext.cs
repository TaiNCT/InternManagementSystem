using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace IMSBussinessObjects
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DocumentRequest> DocumentRequests { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
        public virtual DbSet<Intern> Interns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config.GetConnectionString("SqlDbConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configuration if necessary

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Intern)
                .WithMany(i => i.Documents)
                .HasForeignKey(d => d.InternId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Intern)
                .WithMany(i => i.Notifications)
                .HasForeignKey(n => n.InternId);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Team)
                .WithMany(t => t.Assignments)
                .HasForeignKey(a => a.TeamId);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Intern)
                .WithMany(i => i.Assignments)
                .HasForeignKey(a => a.InternId);

            modelBuilder.Entity<Supervisor>()
                .HasOne(s => s.User)
                .WithMany(u => u.Supervisors)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Supervisor>()
                .HasOne(s => s.Team)
                .WithMany(t => t.Supervisors)
                .HasForeignKey(s => s.TeamId);

            modelBuilder.Entity<Intern>()
                .HasOne(i => i.User)
                .WithOne(u => u.Intern)
                .HasForeignKey<Intern>(i => i.UserId);

            modelBuilder.Entity<Intern>()
                .HasOne(i => i.Team)
                .WithMany(t => t.Interns)
                .HasForeignKey(i => i.TeamId);
        }
    }
}