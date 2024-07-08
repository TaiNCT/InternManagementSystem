using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IMSBussinessObjects
{
    public class IMSDbContext : DbContext
    {
        public IMSDbContext()
        {
        }

        public IMSDbContext(DbContextOptions<IMSDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TrainingUnit> TrainingUnits { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<InternSolution> InternSolutions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

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

            // Configure composite keys
            modelBuilder.Entity<Question>().HasKey(q => new { q.QuizId, q.QuestionId });
            modelBuilder.Entity<InternSolution>().HasKey(i => new { i.QuizId, i.QuestionId });
            modelBuilder.Entity<Feedback>().HasKey(f => new { f.TrainingUnitId, f.UserId, f.MentorId, f.QuizId });
            modelBuilder.Entity<Attendance>().HasKey(a => new { a.ClassId, a.TraineeId, a.Date });
            modelBuilder.Entity<Enrollment>().HasKey(e => new { e.ClassId, e.TraineeId });
            modelBuilder.Entity<Permission>().HasKey(p => new { p.PermissionId, p.RoleID });
            modelBuilder.Entity<UserRole>().HasKey(u => new { u.RoleId });
            modelBuilder.Entity<Quiz>().HasKey(q => q.QuizId);
            modelBuilder.Entity<Class>().HasKey(c => new { c.ClassId });
            modelBuilder.Entity<Course>().HasKey(c => new { c.CourseId });
            modelBuilder.Entity<TrainingUnit>().HasKey(t => new { t.UnitId });
            modelBuilder.Entity<User>().HasKey(u => new { u.UserId });



            // Configure foreign key relationships with OnDelete behavior
            modelBuilder.Entity<TrainingUnit>()
                .HasOne(t => t.Quiz)
                .WithMany()
                .HasForeignKey(t => t.QuizId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary

            // Configure foreign key relationships with OnDelete behavior
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany()
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary

            // Configure foreign key relationships with OnDelete behavior
            modelBuilder.Entity<InternSolution>()
                .HasOne(i => i.Question)
                .WithMany()
                .HasForeignKey(i => new { i.QuizId, i.QuestionId })
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary

            // Configure foreign key relationships with OnDelete behavior
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.TrainingUnit)
                .WithMany()
                .HasForeignKey(f => f.TrainingUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Mentor)
                .WithMany()
                .HasForeignKey(f => f.MentorId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Quiz)
                .WithMany()
                .HasForeignKey(f => f.QuizId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Instructor)
                .WithMany()
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary
        }

    }
}
