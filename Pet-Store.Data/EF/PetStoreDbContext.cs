using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.Entities;

namespace Pet_Store.Data.EF
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=DESKTOP-FGFA33A;Initial Catalog=PetStoreDB;Persist Security Info=True;User ID=sa;Password=1234");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutDetail> AboutDetails { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetail> BlogsDetails { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceDetail> ServicesDetails { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<VoucherCode> VoucherCodes { get; set; }
    }
}