using System.ComponentModel.DataAnnotations;

namespace BlogManagementModule.Constants.EnumClass
{
    public enum EBlogStatus
    {
        [Display(Name = "Published")]
        Published,
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Inactive")]
        Inactive
    }
    public enum EUserRoles
    {
        [Display(Name = "Admin")]
        Administrator = 1,
        [Display(Name = "User")]
        User = 2,
        [Display(Name = "Guest")]
        Guest = 3,
        // ... So on
    }
}
