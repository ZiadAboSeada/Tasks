using Microsoft.EntityFrameworkCore;

namespace Task_2.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base() 
        { 

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=task2;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");
        }
        public DbSet<Category> categories {  get; set; }
        public DbSet <Customer> customers { get; set; }
        public DbSet <Order> orders { get; set; }
        public DbSet <Product> products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}