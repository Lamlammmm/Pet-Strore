using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.Entities;
using Pet_Store.Data.UnitOfWork;

namespace Pet_Store.Data.EF
{
    public class PetStoreDbContext : IdentityDbContext<User, Role, string>, IUnitOfWork
    {
        public PetStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            if (result > 0)
                return true;
            else
                return false;
        }

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
        public DbSet<ServicePet> ServicesPet { get; set; }
        public DbSet<ServicePetDetail> ServicesDetails { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<VoucherCode> VoucherCodes { get; set; }
        public DbSet<Data.Entities.Files> Files { get; set; }
    }
}