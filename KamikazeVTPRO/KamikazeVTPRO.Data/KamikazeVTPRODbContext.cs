using KamikazeVTPRO.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace KamikazeVTPRO.Data
{
    public class KamikazeVTPRODbContext : IdentityDbContext<ApplicationUser>
    {
        public KamikazeVTPRODbContext() : base("KamikazeVTPROConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }
        
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(x => x.UserId);
        }

        public static KamikazeVTPRODbContext Create()
        {
            return new KamikazeVTPRODbContext();
        }
    }
}