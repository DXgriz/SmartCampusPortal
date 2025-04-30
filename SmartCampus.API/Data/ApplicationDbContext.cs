using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCampus.API.Models;

namespace SmartCampus.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
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
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Roles (Important for setting up roles)
            builder.Entity<UserRole>().HasData(
                new UserRole { RoleId = 1, RoleName = "Student" },
                new UserRole { RoleId = 2, RoleName = "Lecturer" },
                new UserRole { RoleId = 3, RoleName = "Administrator" }
            );

            // Configure the relationship between Timetable and Users
            builder.Entity<Timetable>()
                .HasOne(t => t.Lecturer)
                .WithMany()
                .HasForeignKey(t => t.LecturerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            // Define the many-to-many relationship between Timetable and Student.
            //  This is now handled through the StudentIds property in the Timetable model.
            // builder.Entity<Timetable>()
            //     .HasMany(t => t.Students)
            //     .WithMany()
            //     .UsingEntity(j => j.ToTable("TimetableStudent"));  // You don't need this join table

            //Set Schema
            builder.HasDefaultSchema("SmartCampus");
        }
    }
}
