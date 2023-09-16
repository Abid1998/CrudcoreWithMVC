using Microsoft.EntityFrameworkCore; //add name Space


namespace CrudcoreWithMVC.Models
{

    public class StudentDbContext : DbContext // Db Contect Class Inheritance
    {
        //constructor parameterized - sort ctor 
        public StudentDbContext(DbContextOptions options) : base(options) // base to call parent class DbContext
        {
            
        }
        //Db Set Generic Property 
        public  DbSet<Student> Students { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
