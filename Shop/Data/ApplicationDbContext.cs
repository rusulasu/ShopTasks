using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Constructor (mandatory) to passing "options"
        }

        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }

        public DbSet<BlogType> blogTypes { get; set; }

        public DbSet<Blog> blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Custom Congifration
                                                                           //something to do when db created (default values)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Nike" },
                new Company { Id = 2, Name = "Adidas" }
                );

            modelBuilder.Entity<BlogType>().HasData(
                new BlogType { Id = 1, Category = "Fashion" },
                new BlogType { Id = 2, Category = "Travel" },
                new BlogType { Id = 3, Category = "Food" },
                new BlogType { Id = 4, Category = "Health" },
                new BlogType { Id = 5, Category = "Sport" },
                new BlogType { Id = 6, Category = "Comedy" }
                );
        }



        internal object FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}