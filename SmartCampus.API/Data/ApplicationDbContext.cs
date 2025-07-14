using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCampus.API.Models;

namespace SmartCampus.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        // DO NOT redefine UserRoles manually
        // public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Prevent multiple cascade paths
            builder.Entity<IdentityUserRole<int>>()
                .HasOne<User>() 
                .WithMany()
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            builder.Entity<IdentityUserRole<int>>()
                .HasOne<UserRole>() 
                .WithMany()
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Use Identity's standard AspNetRoles table  
            builder.Entity<UserRole>().ToTable("AspNetRoles");

            builder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, Name = "Student", NormalizedName = "STUDENT", RoleName = "Student" },
                new UserRole { Id = 2, Name = "Lecturer", NormalizedName = "LECTURER", RoleName = "Lecturer" },
                new UserRole { Id = 3, Name = "Administrator", NormalizedName = "ADMINISTRATOR", RoleName = "Administrator" }
            );

            builder.Entity<Timetable>()
                .HasOne(t => t.Lecturer)
                .WithMany()
                .HasForeignKey(t => t.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
