using System;
using Challenge.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Challenge.Api.Data
{
    public class CategoryContext(DbContextOptions<CategoryContext> options)
            : DbContext(options)
    {
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new { Id = 1, CategoryName = "Fiction" },
                    new { Id = 2, CategoryName = "Non-Fiction" },
                    new { Id = 3, CategoryName = "Science Fiction" },
                    new { Id = 4, CategoryName = "Fantasy" },
                    new { Id = 5, CategoryName = "Mystery" },
                    new { Id = 6, CategoryName = "Thriller" },
                    new { Id = 7, CategoryName = "Romance" },
                    new { Id = 8, CategoryName = "Fiction" },
                    new { Id = 9, CategoryName = "Non-Fiction" },
                    new { Id = 10, CategoryName = "Science Fiction" }
            );
        }
    }
}