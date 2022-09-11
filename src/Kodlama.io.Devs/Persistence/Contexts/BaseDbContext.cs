﻿using Core.Security.Entities;
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

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgramingLanguages").HasKey(k => k.Id);
                //a.Property(p => p.Id).HasColumnName("Id");
                //a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.LanguageTechnologies);
            });

            modelBuilder.Entity<LanguageTechnology>(a =>
            {
                a.ToTable("LanguageTechnologies").HasKey(k => k.Id);
                //a.Property(p => p.Id).HasColumnName("Id");
                //a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.HasMany(a => a.UserOperationClaims);
            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.HasOne(a => a.User);
                a.HasOne(a => a.OperationClaim);
            });

            ProgrammingLanguage[] programingLanguage = { new ProgrammingLanguage(1, "C#") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programingLanguage);


            LanguageTechnology[] languageTechnologies = { new LanguageTechnology(1,1,"asp.net") };
            modelBuilder.Entity<LanguageTechnology>().HasData(languageTechnologies);
        }
    }
}
