using BlogManagementModule.Constants.EnumClass;
using BlogManagementModule.Models.SystemModels;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BlogManagementModule.Models.BlogEntities
{
    public class BlogCategories :EntityIdentityModel<int>
    {
        [Required]
        public string CategoryName { get; set; }
        [AllowNull]
        public string CategoryDescription { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
    public class BlogFileInformation : BasicIdentityRootModel<long>
    {
        public virtual BlogAccount BlogAccount { get; set; }
        [Required]
        public virtual long BlogId { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileLocation { get; set; }  
        [Required]
        public long FileSize { get; set; }
        [Required]
        public bool IsDeleted { get; set; } 
    }
    public class BlogAccount : FullIdentityRootModel <long>
    {
        public virtual BlogCategories BlogCategory { get; set; }
        [Required]
        public int BlogCategoryId { get; set; }
        [Required]
        public string BlogName { get; set; } // Title
        [Required]
        public string BlogDescription { get; set; }
        [Required]
        public EBlogStatus BlogStatus { get; set; }
        //-----------------------------------------
        [Required]
        // When `Admin` Add some date (like Current Date is `2023-05-15` PublishedDate is `2023-06-10`
        // this case client seen this blog after 25 days. this is auto publish after 25 days latter
        // This is for make automatic Publish after few times latter.
        public DateTime PublishedDate { get; set; }
        //-----------------------------------------
        //-----------------------------------------
        // When some blog need auto expiry some time letter then add date here.
        // If This colulmns have null value then this for Lifetime not exiry otherwire CurrentTime>ExpiryDate then Auto hide Blog from client side
        public DateTime? ExpiryDate { get; set; }
        //-----------------------------------------
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public bool IsAllowPublicComment { get; set; }
        //---------------------------------
        [Required] // This is for how many times user request for view this blog.
        // It is posible to make saprate tables.
        // But We store this value here then RunTime Executing Query Time make fater
        public long ViewCount { get; set; } = 0;
        //---------------------------------
    }
    public class BlogComments : FullIdentityRootModel<long>
    {
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        //-----------------------------------------
        // This only used by `admin` (when comes bad comments or why delete this comment)
        // This is hidden only seen by `admin`
        public string DeleteRemarks { get; set; }
        //-----------------------------------------
    }
    public class BlogViewHistory :BasicIdentityRootModel<long>
    {
        // sent request by `Admin, User, Guest` then we allow count only `Guest or User` 
        // Admin Count not allow but add for save history 
        public bool IsPublicUser { get; set; }  
    }
}
