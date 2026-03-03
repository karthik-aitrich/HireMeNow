using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class DbHireMeNowWebApiContext : DbContext
{
    public DbHireMeNowWebApiContext(DbContextOptions<DbHireMeNowWebApiContext> options)
        : base(options)
    {
    }

    public DbSet<AuthUser> AuthUsers { get; set; }
    public DbSet<CompanyUser> CompanyUsers { get; set; }
    public DbSet<Industry> Industries { get; set; }
    public DbSet<JobCategory> JobCategories { get; set; }
    public DbSet<JobPost> JobPosts { get; set; }
    public DbSet<JobProviderCompany> JobProviderCompanies { get; set; }
    public DbSet<JobResponsibility> JobResponsibilities { get; set; }
    public DbSet<JobSeeker> JobSeekers { get; set; }
    public DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Qualification> Qualifications { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SystemUser> SystemUsers { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }
    public DbSet<Applicationn> Applications { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<CandidateReview> CandidateReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // ================= GLOBAL GUID AUTO GENERATION =================
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var idProp = entity.FindProperty("Id");
            if (idProp != null && idProp.ClrType == typeof(Guid))
            {
                idProp.SetDefaultValueSql("NEWID()");
            }
        }

        // ================= AUTH USER =================
        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.SystemUser)
                  .WithOne(p => p.AuthUser)
                  .HasForeignKey<AuthUser>(d => d.SystemUserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ================= SYSTEM USER =================
        modelBuilder.Entity<SystemUser>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasDefaultValueSql("NEWID()");

            entity.Property(e => e.Email).HasMaxLength(450);
        });

        // ================= JOB SEEKER (Shared PK with SystemUser) =================
        modelBuilder.Entity<JobSeeker>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .ValueGeneratedNever(); // shared PK

            entity.HasOne(d => d.SystemUser)
                  .WithOne(p => p.JobSeeker)
                  .HasForeignKey<JobSeeker>(d => d.Id)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ================= INDUSTRY =================
        modelBuilder.Entity<Industry>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
        });

        // ================= JOB CATEGORY =================
        modelBuilder.Entity<JobCategory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
        });

        // ================= LOCATION =================
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
        });

        // ================= JOB PROVIDER COMPANY =================
        modelBuilder.Entity<JobProviderCompany>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.LocationNavigation)
                  .WithMany(p => p.JobProviderCompanies)
                  .HasForeignKey(d => d.Location)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        // ================= COMPANY USER =================
        modelBuilder.Entity<CompanyUser>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.CompanyNavigation)
                  .WithMany(p => p.CompanyUsers)
                  .HasForeignKey(d => d.Company);
        });

        // ================= JOB POST =================
        modelBuilder.Entity<JobPost>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.JobLocationNavigation)
                  .WithMany(p => p.JobPosts)
                  .HasForeignKey(d => d.JobLocation)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.PostedByNavigation)
                  .WithMany()
                  .HasForeignKey(d => d.PostedBy)
                  .OnDelete(DeleteBehavior.Restrict)
                  .IsRequired();   // 🔥 important
        });

        // ================= JOB RESPONSIBILITY =================
        modelBuilder.Entity<JobResponsibility>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.JobPostNavigation)
                  .WithMany(p => p.JobResponsibilities)
                  .HasForeignKey(d => d.JobPost)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ================= JOB SEEKER PROFILE =================
        modelBuilder.Entity<JobSeekerProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
        });

        // ================= RESUME =================
        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.ResumeId);

            entity.Property(e => e.ResumeId)
                  .HasDefaultValueSql("NEWID()");

            entity.HasOne(r => r.JobSeekerProfile)
                  .WithMany(p => p.Resumes)
                  .HasForeignKey(r => r.SeekerProfileId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ================= QUALIFICATION =================
        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.JobPost)
                  .WithMany(p => p.Qualifications)
                  .HasForeignKey(d => d.JobPostId);

            entity.HasOne(d => d.JobSeekerProfile)
                  .WithMany(p => p.Qualifications)
                  .HasForeignKey(d => d.JobSeekerProfileId);


        });

        // ================= SKILL =================
        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.JobPostNavigation)
                  .WithMany(p => p.Skills)
                  .HasForeignKey(d => d.JobPost)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ================= WORK EXPERIENCE =================
        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.HasKey(e => e.WorkId);
            entity.Property(e => e.WorkId).HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.JobSeekerProfile)
                  .WithMany(p => p.WorkExperiences)
                  .HasForeignKey(d => d.JobSeekerProfileId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ================= APPLICATION =================
        modelBuilder.Entity<Applicationn>(entity =>
        {
            entity.HasKey(e => e.ApplicationId);

            entity.Property(e => e.ApplicationId)
                  .HasDefaultValueSql("NEWID()");
        });

        // ================= INTERVIEW =================
        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.InterviewId); // ✅ FIXED

            entity.Property(e => e.InterviewId)
                  .HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.Application)
                  .WithMany(a => a.Interviews)
                  .HasForeignKey(d => d.ApplicationId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ================= CANDIDATE REVIEW =================
        modelBuilder.Entity<CandidateReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId);

            entity.Property(e => e.ReviewId)
                  .HasDefaultValueSql("NEWID()");
        });
    }
}