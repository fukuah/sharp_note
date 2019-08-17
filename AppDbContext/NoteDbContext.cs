using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharpNote.AppDbContext.Entities;

namespace SharpNote.AppDbContext
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext()
        {
            if (Database.EnsureCreated())
                Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = config.GetConnectionString("notedbconnection"); 

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().ToTable("Note");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
