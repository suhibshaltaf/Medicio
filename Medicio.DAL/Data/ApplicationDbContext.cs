using Medicio.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medicio.DLL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Department)
                .WithMany()
                .HasForeignKey(a => a.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); 
        
            var roleAdminId = Guid.NewGuid().ToString();
            var SuperAdminId = Guid.NewGuid().ToString();

            var UserId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = roleAdminId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = SuperAdminId, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole { Id = UserId, Name = "User", NormalizedName = "USER" }
                );
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@medc.com",
                NormalizedUserName = "ADMIN@MEDC.COM",
                Email = "admin@medc.com",
                NormalizedEmail = "ADMIN@MEDC.COM",
                EmailConfirmed = true,
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Sohaib@18");

            var SuperUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "superadmin@medc.com",
                NormalizedUserName = "SUPERADMIN@MEDC.COM",

                Email = "superadmin@medc.com",
                NormalizedEmail = "SUPERADMIN@MEDC.COM",
                EmailConfirmed = true,
            };
            SuperUser.PasswordHash = hasher.HashPassword(SuperUser, "Sohaib@18");
            var User = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@medc.com",
                NormalizedUserName = "USER@MEDC.COM",

                Email = "user@medc.com",
                NormalizedEmail = "USER@MEDC.COM",
                EmailConfirmed = true,
            };
            User.PasswordHash = hasher.HashPassword(User, "Sohaib@18");
            builder.Entity<ApplicationUser>().HasData(adminUser, SuperUser, User);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = UserId, UserId = User.Id },
                 new IdentityUserRole<string> { RoleId = roleAdminId, UserId = adminUser.Id }, new IdentityUserRole<string> { RoleId = SuperAdminId, UserId = SuperUser.Id }



                );
        }
        public DbSet<Service> Services {  get; set; }
        public DbSet<Departments> departments { get; set; }
        public DbSet<Doctors>  doctors{ get; set; }
        public DbSet<Testimonials> testimonials { get; set; }
        public DbSet<Questions> questions { get; set; }
        public DbSet<Pricing>  pricings { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Slider>  sliders { get; set; }
        public DbSet<Features>  features { get; set; }

        

    }
}
