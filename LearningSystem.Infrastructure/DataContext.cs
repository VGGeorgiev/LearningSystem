namespace LearningSystem.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using LearningSystem.Core.Entities;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserInCourse> UsersInCourses { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<HomeworkAssignment> HomeworkAssignments { get; set; }

        public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }

        public DbSet<HomeworkEvaluation> HomeworkEvaluations { get; set; }
        
        public DbSet<Course> Courses { get; set; }
        
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomeworkEvaluation>()
                .HasOne(x => x.HomeworkSubmission)
                .WithMany(x => x.HomeworkEvaluations)
                .HasForeignKey(x => x.HomeworkSubmissionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HomeworkSubmission>()
                .HasOne(x => x.HomeworkAssignment)
                .WithMany(x => x.HomeworkSubmissions)
                .HasForeignKey(x => x.HomeworkAssignmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HomeworkAssignment>()
                .HasOne(x => x.Lecture)
                .WithMany(x => x.HomeworkAssignments)
                .HasForeignKey(x => x.LectureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}