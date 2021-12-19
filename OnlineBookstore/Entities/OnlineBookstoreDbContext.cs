using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.Entities
{
    public class OnlineBookstoreDbContext : DbContext
    {
        public OnlineBookstoreDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; } 
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }        
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<InstanceBook> InstanceBooks { get; set; }
        public object Users { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<InstanceBook>()
                .Property(a => a.Price)
                .HasPrecision(19, 2); 
            
            modelBuilder.Entity<BookCategory>()
                .HasKey(a => new {a.BookId,a.CategoryId});
            modelBuilder.Entity<AuthorBook>()
             .HasKey(a => new { a.AuthorID, a.BookId });

            modelBuilder.Entity<ShoppingBasket>()
                .HasOne(a => a.Order)
                .WithOne(a => a.ShoppingBasket)
                .HasForeignKey<Order>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);
                
           
           
           
        }

    }

}
