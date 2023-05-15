using BlogManagementModule.Models;
using BlogManagementModule.Models.BlogEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogManagementModule.Database
{
    public class DatabaseConfiguration : DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(this._configuration.GetConnectionString("default"));
        }
        public DbSet<UserAccounts> userAccounts { get; set; }
        //public DbSet<UserGrandPermission> userGrandPermissions { get; set; }
        public DbSet<BlogCategories> clogCategories { get; set; }
        public DbSet<BlogFileInformation> blogFileInformations { get; set; }
        public DbSet<BlogAccount> blogAccounts { get; set; }
        public DbSet<BlogComments> blogComments { get; set; }
        public DbSet<BlogViewHistory> blogViewHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            
            DataSeeding(b);
        }

        private void DataSeeding (ModelBuilder b)
        {

        }
    }

}
