using BlogManagementModule.Constants.EnumClass;
using BlogManagementModule.Models.SystemModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogManagementModule.Models
{
    //public class UserRoles : BasicIdentityRootModel<int>
    //{
    //    [Required,MinLength(3), MaxLength(20)]
    //    public string RoleName { get; set; }
    //}
    public class UserAccounts : FullIdentityRootModel<long>
    {
        public EUserRoles Roles { get; set; }
        [Required,MinLength(6), MaxLength(30)]
        public string Username { get; set; }
        [Required,MinLength(8), MaxLength(200)]
        public string Password { get; set; } // Hashing Value
        [Required,MinLength(10), MaxLength(100)]
        public string EmailAddress { get; set; }
        [Required,MinLength(10), MaxLength(15)]
        public string MobileNumber { get; set; }
        [Required,MinLength(5), MaxLength(100)]
        public string PermanentAddress { get; set; }
        // TODO: Profile Image System
    }
    public class UserGrandPermission : BasicIdentityRootModel<int>
    {
        // TODO:
    }
}
