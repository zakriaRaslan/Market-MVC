// Ignore Spelling: App

namespace Market.Data.Data
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("DECIMAL(10,3)");

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothes" },
                 new Category { Id = 3, Name = "Computers" }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Product1",
                    Description = "Description1",
                    CategoryId = 2,
                    Price = 1100,
                },
                 new Product
                 {
                     Id = 2,
                     Title = "Product2",
                     Description = "Description2",
                     CategoryId = 1,
                     Price = 1140,
                 }, new Product
                 {
                     Id = 3,
                     Title = "Product3",
                     Description = "Description3",
                     CategoryId = 1,
                     Price = 1200,
                 }, new Product
                 {
                     Id = 4,
                     Title = "Product4",
                     Description = "Description4",
                     CategoryId = 3,
                     Price = 11500,
                 }, new Product
                 {
                     Id = 5,
                     Title = "Product5",
                     Description = "Description5",
                     CategoryId = 3,
                     Price = 1100,
                 }, new Product
                 {
                     Id = 6,
                     Title = "Product6",
                     Description = "Description6",
                     CategoryId = 1,
                     Price = 1100,
                 }, new Product
                 {
                     Id = 7,
                     Title = "Product7",
                     Description = "Description7",
                     CategoryId = 2,
                     Price = 11004,
                 }, new Product
                 {
                     Id = 8,
                     Title = "Product8",
                     Description = "Description8",
                     CategoryId = 2,
                     Price = 1100,
                 }
                );
        }
    }
}
