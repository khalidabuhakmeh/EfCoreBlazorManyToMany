using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Models
{
    public class Database : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new List<Category>
                {
                    new() {Id = 1, Name = "American"},
                    new() {Id = 2, Name = "Mexican"},
                    new() {Id = 3, Name = "Japanese"},
                    new() {Id = 4, Name = "Chinese"},
                });

            modelBuilder.Entity<Food>()
                .HasData(new List<Food>
                {
                    new() {Id = 1, Name = "Nachos"},
                    new() {Id = 2, Name = "Pizza"},
                    new() {Id = 3, Name = "Tacos"},
                    new() {Id = 4, Name = "Noodles"},
                    new() {Id = 5, Name = "Sushi"},
                });
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Food> Foods { get; set; }
    }

    public class Food
    {
        public int Id { get; set; }
        public ICollection<Category> Categories { get; set; }
        public string Name { get; set; }
    }
}