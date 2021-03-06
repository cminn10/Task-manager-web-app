using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class TaskManagerDbContext: DbContext
    {
        public TaskManagerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppTask> Tasks { get; set; }
        public DbSet<TaskHistory> TasksHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(ConfigureUser);
            modelBuilder.Entity<AppTask>(ConfigureTask);
            modelBuilder.Entity<TaskHistory>(ConfigureTaskHistory);
        }

        private void ConfigureUser(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(1024);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Fullname).HasMaxLength(50);
            builder.Property(u => u.Mobileno).HasMaxLength(50);
        }

        private void ConfigureTask(EntityTypeBuilder<AppTask> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.Remarks).HasMaxLength(500);
            builder.Property(t => t.Priority).HasDefaultValue("E");

            builder.HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);
        }

        private void ConfigureTaskHistory(EntityTypeBuilder<TaskHistory> builder)
        {
            builder.ToTable("Tasks History");
            builder.HasKey(h => h.TaskId);
            builder.Property(h => h.TaskId).ValueGeneratedNever();
            builder.Property(h => h.UserId).IsRequired();
            builder.Property(h => h.Title).HasMaxLength(50);
            builder.Property(h => h.Description).HasMaxLength(500);
            builder.Property(h => h.Remarks).HasMaxLength(500);
            builder.Property(h => h.Completed).HasDefaultValueSql("CURRENT_DATE");
            
            builder.HasOne(t => t.User)
                .WithMany(u => u.TasksHistories)
                .HasForeignKey(h => h.UserId);
        }
    }
}