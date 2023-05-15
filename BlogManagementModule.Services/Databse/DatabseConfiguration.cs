using BlogManagementModule.Constants.EnumClass;
using BlogManagementModule.Constants.SystemClass;
using BlogManagementModule.Models;
using BlogManagementModule.Models.BlogEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogManagementModule.Database
{
    public class DatabaseConfiguration : DbContext
    {
        // This value is 2023-05-15 09:25 PM (LocalTime)
        readonly DateTime defaultDateTime = new DateTime(638197619788951135);

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
        public DbSet<BlogCategories> blogCategories { get; set; }
        public DbSet<BlogFileInformation> blogFileInformations { get; set; }
        public DbSet<BlogAccount> blogAccounts { get; set; }
        public DbSet<BlogComments> blogComments { get; set; }
        public DbSet<BlogViewHistory> blogViewHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            b.Entity<UserAccounts>(b =>
            {
                b.ToTable(nameof(userAccounts));
                b.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");
                b.Property(x => x.Roles).IsRequired(true).HasDefaultValue(EUserRoles.User);
                b.Property(x => x.Username).IsRequired(true);
                b.Property(x => x.CreationTime).IsRequired(true);
                b.Property(x => x.IsDelete).IsRequired(true).HasDefaultValue(false);
                b.Property(x => x.Password).IsRequired(true);
                b.Property(x => x.EmailAddress).IsRequired(true);
                b.Property(x => x.MobileNumber).IsRequired(false);
                b.Property(x => x.PermanentAddress).IsRequired(false);
                b.HasOne(F => F.LastModified).WithMany().HasForeignKey(F => F.LastModifiedId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(F => F.Deletor).WithMany().HasForeignKey(F => F.DeletorId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            });

            b.Entity<BlogCategories>(b =>
            {
                b.ToTable(nameof(blogCategories));
                b.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");
                b.Property(x => x.CategoryName).IsRequired(true);
                b.Property(x => x.CategoryDescription).IsRequired(false);
                b.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);
            });

            b.Entity<BlogAccount>(b =>
            {
                b.ToTable(nameof(blogAccounts));
                b.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");
                b.Property(x => x.BlogName).IsRequired(true);
                b.Property(x => x.BlogDescription).IsRequired(false);
                b.Property(x => x.PublishedDate).IsRequired(false).HasDefaultValue(null);
                b.Property(x => x.ExpiryDate).IsRequired(false).HasDefaultValue(null);
                b.Property(x => x.IsPublic).IsRequired(true).HasDefaultValue(true);
                b.Property(x => x.IsAllowPublicComment).IsRequired(true).HasDefaultValue(true);
                b.Property(x => x.ViewCount).IsRequired(true).HasDefaultValue(0);
                b.Property(x => x.CreationTime).IsRequired(true);
                b.Property(x => x.BlogStatus).IsRequired(true).HasDefaultValue(EBlogStatus.Pending);
                b.HasOne(F => F.Creator).WithMany().HasForeignKey(F => F.CreatorId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(F => F.LastModified).WithMany().HasForeignKey(F => F.LastModifiedId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(F => F.Deletor).WithMany().HasForeignKey(F => F.DeletorId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(F => F.BlogCategory).WithMany().HasForeignKey(F => F.BlogCategoryId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            });

            b.Entity<BlogComments>(b =>
            {
                b.ToTable(nameof(blogComments));
                b.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");
                b.Property(x => x.Comment).IsRequired(true);
                b.Property(x => x.IsDelete).IsRequired(true).HasDefaultValue(false);
                b.Property(x => x.DeleteRemarks).IsRequired(false);
                b.Property(x => x.CreationTime).IsRequired(true);
                b.HasOne(F => F.Creator).WithMany().HasForeignKey(F => F.CreatorId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(F => F.LastModified).WithMany().HasForeignKey(F => F.LastModifiedId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(F => F.Deletor).WithMany().HasForeignKey(F => F.DeletorId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(F => F.BlogAccount).WithMany().HasForeignKey(F => F.BlogId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            });

            b.Entity<BlogViewHistory>(b =>
            {
                b.ToTable(nameof(blogViewHistory));
                b.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");
                b.Property(x => x.IsPublicUser).IsRequired(true).HasDefaultValue(true);
                b.Property(x => x.CreationTime).IsRequired(true);
                b.HasOne(F => F.Creator).WithMany().HasForeignKey(F => F.CreatorId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(F => F.BlogAccount).WithMany().HasForeignKey(F => F.BlogId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            });

            // Try to set default value in databse
            DataSeeding(b);
        }
        private void DataSeeding (ModelBuilder b)
        {
            b.Entity<UserAccounts>().HasData(this.GetDefaultUsers());
            b.Entity<BlogCategories>().HasData(this.GetDefaultBlogCategories());
            b.Entity<BlogAccount>().HasData(GetDefaultBlogAccount());
            //b.Entity<BlogComments>().HasData();
            //b.Entity<BlogViewHistory>().HasData();
        }
        private List<UserAccounts> GetDefaultUsers()
        {
            return new List<UserAccounts>
            {
                new UserAccounts { Id = 1,EmailAddress = "bijay.adhikari.27648@gmail.com", PermanentAddress = "Lalbandi,Sarlahi",CreationTime = defaultDateTime,MobileNumber = "+977-9865413772",Password = Encriptionystem.EncryptText("Pass@12345", "Hashing01"), Roles = EUserRoles.Administrator, Username = "Bijay_Admin", },
                new UserAccounts { Id = 2,EmailAddress = "bjsoft1@gmail.com", PermanentAddress = "Lalbandi,Sarlahi",CreationTime = defaultDateTime,MobileNumber = "+977-9827876333",Password = Encriptionystem.EncryptText("Pass@12345", "Hashing01"), Roles = EUserRoles.User, Username = "Bijay_User", },
                new UserAccounts { Id = 3,EmailAddress = "bijay.adhikari1@gmail.com", PermanentAddress = "Lalbandi,Sarlahi",CreationTime = defaultDateTime,MobileNumber = "+977-9800000000",Password = Encriptionystem.EncryptText("Pass@12345", "Hashing01"), Roles = EUserRoles.User, Username = "Bijay_User1", },
                new UserAccounts { Id = 4,EmailAddress = "bijay.adhikari2@gmail.com", PermanentAddress = "Lalbandi,Sarlahi",CreationTime = defaultDateTime,MobileNumber = "+977-9800000001",Password = Encriptionystem.EncryptText("Pass@12345", "Hashing01"), Roles = EUserRoles.User, Username = "Bijay_User2", },
                new UserAccounts { Id = 5,EmailAddress = "bijay.adhikari3@gmail.com", PermanentAddress = "Lalbandi,Sarlahi",CreationTime = defaultDateTime,MobileNumber = "+977-9800000002",Password = Encriptionystem.EncryptText("Pass@12345", "Hashing01"), Roles = EUserRoles.User, Username = "Bijay_User3", },
                new UserAccounts { Id = 6,EmailAddress = "bijay.adhikari4@gmail.com", PermanentAddress = "Lalbandi,Sarlahi",CreationTime = defaultDateTime,MobileNumber = "+977-9800000003",Password = Encriptionystem.EncryptText("Pass@12345", "Hashing01"), Roles = EUserRoles.User, Username = "Bijay_User4", },
            };
        }
        private List<BlogCategories> GetDefaultBlogCategories()
        {
            return new List<BlogCategories> 
            {
                new BlogCategories { Id = 1, IsActive = true, CategoryName = "IT"},
                new BlogCategories { Id = 2, IsActive = true, CategoryName = "Bank"},
                new BlogCategories { Id = 3, IsActive = true, CategoryName = "School"},
                new BlogCategories { Id = 4, IsActive = true, CategoryName = "Collage"},
                new BlogCategories { Id = 5, IsActive = true, CategoryName = "Account"},
                new BlogCategories { Id = 6, IsActive = true, CategoryName = "Coding"},
                new BlogCategories { Id = 7, IsActive = true, CategoryName = "GameDevelopment"},
                new BlogCategories { Id = 8, IsActive = true, CategoryName = "UnrealEngine"},
                new BlogCategories { Id = 9, IsActive = true, CategoryName = "C++"},
            };
        }
        private List<BlogAccount> GetDefaultBlogAccount()
        {
            return new List<BlogAccount> 
            {
                new BlogAccount { Id = 1, BlogCategoryId = 1,IsAllowPublicComment = true, BlogDescription = "Hello", BlogName = "Title1", BlogStatus = EBlogStatus.Published,CreatorId = 1, IsPublic = true},
                new BlogAccount { Id = 2, BlogCategoryId = 1,IsAllowPublicComment = true, BlogDescription = "Hello", BlogName = "Title1", BlogStatus = EBlogStatus.Published,CreatorId = 1, IsPublic = true},
                new BlogAccount { Id = 3, BlogCategoryId = 1,IsAllowPublicComment = true, BlogDescription = "Hello", BlogName = "Title1", BlogStatus = EBlogStatus.Published,CreatorId = 1, IsPublic = true},
                new BlogAccount { Id = 4, BlogCategoryId = 1,IsAllowPublicComment = true, BlogDescription = "Hello", BlogName = "Title1", BlogStatus = EBlogStatus.Published,CreatorId = 1, IsPublic = true},
                new BlogAccount { Id = 5, BlogCategoryId = 1,IsAllowPublicComment = true, BlogDescription = "Hello", BlogName = "Title1", BlogStatus = EBlogStatus.Published,CreatorId = 1, IsPublic = true},
                new BlogAccount { Id = 6, BlogCategoryId = 1,IsAllowPublicComment = true, BlogDescription = "Hello", BlogName = "Title1", BlogStatus = EBlogStatus.Published,CreatorId = 1, IsPublic = true},
                new BlogAccount { Id = 7, BlogCategoryId = 1,IsAllowPublicComment = true, BlogDescription = "Hello", BlogName = "Title1", BlogStatus = EBlogStatus.Published,CreatorId = 1, IsPublic = true},
                new BlogAccount { Id = 8, BlogCategoryId = 1,IsAllowPublicComment = true, BlogDescription = "Hello", BlogName = "Title1", BlogStatus = EBlogStatus.Published,CreatorId = 1, IsPublic = true},
            };
        }
    }

}
