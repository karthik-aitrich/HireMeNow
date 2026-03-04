using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class DbHireMeNowWebApiContext : DbContext
{
    public DbHireMeNowWebApiContext(DbContextOptions<DbHireMeNowWebApiContext> options) : base(options)
    {
    }

    public virtual DbSet<JobApplication> JobApplications { get; set; }
    public virtual DbSet<AuthUser> AuthUsers { get; set; }
    public virtual DbSet<CompanyUser> CompanyUsers { get; set; }
    public virtual DbSet<Industry> Industries { get; set; }
    public virtual DbSet<JobCategory> JobCategories { get; set; }
    public virtual DbSet<JobPost> JobPosts { get; set; }
    public virtual DbSet<JobProviderCompany> JobProviderCompanies { get; set; }
    public virtual DbSet<JobResponsibility> JobResponsibilities { get; set; }
    public virtual DbSet<JobSeeker> JobSeekers { get; set; }
    public virtual DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Qualification> Qualifications { get; set; }
    public virtual DbSet<Resume> Resumes { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Skill> Skills { get; set; }
    public virtual DbSet<SystemUser> SystemUsers { get; set; }
    public virtual DbSet<WorkExperience> WorkExperiences { get; set; }
    public virtual DbSet<SavedJob> SavedJobs { get; set; }
    public virtual DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Applicationn> Applications { get; set; }
    public DbSet<Interview> Interviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // JobPost → JobProviderCompany
        modelBuilder.Entity<JobPost>()
            .HasOne(j => j.PostedByNavigation)
            .WithMany(c => c.JobPosts)
            .HasForeignKey(j => j.PostedBy)
            .OnDelete(DeleteBehavior.Restrict);

        // JobSeeker ↔ SystemUser (One-to-One)
        modelBuilder.Entity<JobSeeker>()
            .HasOne(js => js.SystemUser)
            .WithOne(su => su.JobSeeker)
            .HasForeignKey<JobSeeker>(js => js.Id)
            .OnDelete(DeleteBehavior.Restrict);

        // Application Primary Key
        modelBuilder.Entity<Applicationn>()
            .HasKey(a => a.ApplicationId);

        // WorkExperience Primary Key
        modelBuilder.Entity<WorkExperience>()
            .HasKey(w => w.WorkId);

        // JobSeekerProfile → WorkExperience
        modelBuilder.Entity<WorkExperience>()
            .HasOne(w => w.JobSeekerProfile)
            .WithMany(p => p.WorkExperiences)
            .HasForeignKey(w => w.JobSeekerProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        // JobSeekerProfile → SavedJobs
        modelBuilder.Entity<SavedJob>()
            .HasOne(s => s.JobSeekerProfile)
            .WithMany(p => p.SavedJobs)
            .HasForeignKey(s => s.JobSeekerProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        // JobPost → SavedJobs
        modelBuilder.Entity<SavedJob>()
            .HasOne(s => s.JobPost)
            .WithMany(j => j.SavedJobs)
            .HasForeignKey(s => s.JobPostId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}