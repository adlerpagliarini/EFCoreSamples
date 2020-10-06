using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using EFCoreSamples.Domain;
using EFCoreSamples.Infrastructure.Mappings;
using System.IO;
using EFCoreSamples.Domain.Developers;

namespace EFCoreSamples.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Developer> Developer { get; set; }
        public DbSet<FullStackDeveloper> FullStackDeveloper { get; set; }
        public DbSet<FrontEndDeveloper> FrontEndDeveloper { get; set; }
        public DbSet<BackEndDeveloper> BackEndDeveloper { get; set; }
        public DbSet<TaskToDo> TaskToDo { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<TaskToDoSkill> SkillTaskToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeveloperTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TaskToDoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SkillTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TaskToDoSkillTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(MyLoggerFactory);
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
