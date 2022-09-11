using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgramingLanguages { get; set; }
        public DbSet<LanguageTechnology> LanguageTechnologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<ProgrammingLanguage>(x =>
            {
                x.ToTable("ProgramingLanguages").HasKey(x => x.Id);
                //a.Property(p => p.Id).HasColumnName("Id");
                //a.Property(p => p.Name).HasColumnName("Name");
                x.HasMany(p => p.LanguageTechnologies);
            });

            modelBuilder.Entity<LanguageTechnology>(x =>
            {
                x.ToTable("LanguageTechnologies").HasKey(x => x.Id);
                //a.Property(p => p.Id).HasColumnName("Id");
                //a.Property(p => p.Name).HasColumnName("Name");
                x.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<User>(x =>
            {
                x.ToTable("Users").HasKey(x => x.Id);
                x.HasMany(x => x.UserOperationClaims);
            });

            modelBuilder.Entity<OperationClaim>(x =>
            {
                x.ToTable("OperationClaims").HasKey(x => x.Id);
            });

            modelBuilder.Entity<UserOperationClaim>(x =>
            {
                x.ToTable("UserOperationClaims").HasKey(x => x.Id);
                x.HasOne(x => x.User);
                x.HasOne(x => x.OperationClaim);
            });

            modelBuilder.Entity<UserProfile>(x =>
            {
                x.ToTable("UserProfiles").HasKey(x => x.Id);
                x.HasOne(x => x.User);
            });

            ProgrammingLanguage[] programingLanguage = { new ProgrammingLanguage(1, "C#") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programingLanguage);


            LanguageTechnology[] languageTechnologies = { new LanguageTechnology(1,1,"asp.net") };
            modelBuilder.Entity<LanguageTechnology>().HasData(languageTechnologies);
        }
    }
}
