using ConJob.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConJob.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasIndex(p => p.email).IsUnique();
            modelBuilder.Entity<UserModel>()
                        .HasMany(e => e.user_roles)
                        .WithOne(e => e.users)
                        .HasForeignKey("user_id")
                        .IsRequired();

            modelBuilder.Entity<RoleModel>()
                    .HasMany(e => e.user_roles)
                    .WithOne(e => e.roles)
                    .HasForeignKey("role_id")
                    .IsRequired();

            modelBuilder.Entity<JobModel>()
                    .HasMany(e => e.posts)
                    .WithOne(e => e.jobs)
                    .HasForeignKey("job_id")
                    .IsRequired();

            modelBuilder.Entity<UserModel>()
                    .HasMany(e => e.jwts)
                    .WithOne(e => e.users)
                    .HasForeignKey("user_id")
                    .IsRequired();

            modelBuilder.Entity<UserModel>()
                .HasMany(e => e.posts)
                .WithOne(e => e.users)
                .HasForeignKey("user_id");
            modelBuilder.Entity<UserModel>()
                .HasMany(e=>e.likes)
                .WithOne(e => e.users)
                .HasForeignKey("user_id");
             
            modelBuilder.Entity<UserModel>()
                .HasMany(e => e.applicants)
                .WithOne(e => e.users)
                .HasForeignKey("user_id")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserModel>()
                .HasMany(e => e.jobs)
                .WithOne(e => e.users)
                .HasForeignKey("user_id")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserModel>()
                .HasMany(e=>e.from_user_notiofications)
                .WithOne(e=>e.from_user_notifications)
                .HasForeignKey("from_user_notifi_id")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserModel>()
               .HasMany(e => e.to_user_notiofications)
               .WithOne(e => e.to_user_notiofications)
               .HasForeignKey("to_user_notifi_id")
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.followers)
               .WithOne(u => u.from_user_follows)
               .HasForeignKey("from_user_id")
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserModel>()
                .HasMany(u=>u.posts)
                .WithOne(u=>u.users)
                .HasForeignKey("user_id")
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserModel>()
                .HasMany(u=>u.reports)
                .WithOne(u=>u.users)
                .HasForeignKey("user_id")
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserModel>()
                .HasMany(u=>u.send_users)
                .WithOne(u=>u.send_users)
                .HasForeignKey("send_user_id")
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.receive_users)
                .WithOne(u => u.receive_users)
                .HasForeignKey("receive_user_id")
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }


        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<UserRoleModel> UserRoles { get; set; }
        public virtual DbSet<RoleModel> Roles { get; set; }
        public virtual DbSet<ApplicantModel> Applicants { get; set; }
        public virtual DbSet<CategoryModel> Categorys { get; set; }

        public virtual DbSet<FileModel> Files { get; set; }
        public virtual DbSet<FollowModel> Follows { get; set; }
        public virtual DbSet<JobModel> Jobs { get; set; }

        public virtual DbSet<JWTModel> JWTs { get; set; }
        public virtual DbSet<LikeModel> Likes { get; set; }
        public virtual DbSet<NotificationModel> Notifications { get; set; }
        public virtual DbSet<PostModel> Posts { get; set; }
        public virtual DbSet<ReportModel> Reports { get; set; }
        public virtual DbSet<SkillModel> Skills { get; set; }


        #region Auto add created-time, updated-time
        public override int SaveChanges()
        {

            try
            {
                AddTimestamps();
                return base.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                throw;
            }


        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                AddTimestamps();
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving changes: {ex.Message}");
                throw;
            }
        }
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).created_at = now;
                }
                ((BaseModel)entity.Entity).updated_at = now;
            }
        }
        #endregion
    }
}