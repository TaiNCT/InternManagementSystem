using Microsoft.EntityFrameworkCore;

namespace IMSBussinessObjects;
public class ISMDbContext : DbContext
{
    public ISMDbContext(DbContextOptions<ISMDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<TrainingUnit> TrainingUnits { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<InternSolution> InternSolutions { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and constraints if needed    
    }
}