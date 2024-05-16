using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;

namespace Infrastructures
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<CourseMajor> CourseMajors { get; set; }
        public DbSet<FavoriteCourse> FavoriteCourses { get; set; }
        public DbSet<OnlineClass> OnlineClasses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeachingCourse> TeachingCourses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<TutorFeedback> TutorFeedbacks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WeeklyTime> WeeklyTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(GetConnStr()).EnableSensitiveDataLogging()
                    .UseLoggerFactory(LoggerFactory.Create(b => {}));
            }
        }

        private string GetConnStr()
        {
            var configuration =  new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", true, true).Build();
            return configuration?.GetConnectionString("SQLServerDB") ?? "";
        }
        public static async Task SeedDatabase()
        {
            if(Debugger.IsAttached) // Debug only
            using (var context = new AppDbContext(new()))
            {
                using var transaction =await context.Database.BeginTransactionAsync();
                try
                {
                    var dbInit = new DbInitializer(context);
                    dbInit.Seed();
                    await transaction.CommitAsync();
                }catch(Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.ToString());
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}
