using System;
using System.Security.Cryptography.X509Certificates;
using DomainTestWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainTestWebApi.Persistence.Contexts
{
    public class DomainDbContext : DbContext
    {
        public DbSet<MainEntity> MainEntities { get; set; }
        
        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<MainEntity>().HasKey(p => p.Id);
            builder.Entity<MainEntity>().Property(p => p.FirstMainProperty).IsRequired();
            builder.Entity<MainEntity>().Property(p => p.SecondMainProperty);
            builder.Entity<MainEntity>().Property(p => p.DateTimeMainProperty);

            //some data for test
            builder.Entity<MainEntity>().HasData
            (
                new MainEntity
                    {
                        Id = Guid.NewGuid(), 
                        FirstMainProperty = "FirstMainProperty", 
                        SecondMainProperty = "SecondMainProperty",
                        IntMainProperty = 13, 
                        DateTimeMainProperty = DateTime.Now
                    }
                );
        }
    }
}