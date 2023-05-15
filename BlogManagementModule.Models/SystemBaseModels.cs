using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogManagementModule.Models.SystemModels
{
    public class EntityIdentityModel<Identity>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Identity Id { get; set; }
    }
    public class EntityModel<Identity>
    {
        [Required]
        public Identity Id { get; set; }
    }
    public class BasicIdentityRootModel<Idenetity> : EntityIdentityModel<Idenetity>
    {
        [Required, Column(TypeName = "bigint")]
        public virtual long CreatorId { get; set; }
        public virtual UserAccounts Creator { get; set; }
        [Required, Column(TypeName = "timestamp without time zone")]
        public virtual DateTime? CreationTime { get; set; }
    }
    public class BasicRootModel<Identity> : EntityModel<Identity>
    {
        [Required, Column(TypeName = "timestamp without time zone")]
        public virtual DateTime? CreationTime { get; set; }
        [Required, Column(TypeName = "bigint")]
        public virtual long CreatorId { get; set; }
        public virtual UserAccounts Creator { get; set; }
    }
    public class FullIdentityRootModel<Identity> : BasicIdentityRootModel<Identity>
    {
        public virtual long? DeleteTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? DeletorId { get; set; }
        public virtual UserAccounts Deletor { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public virtual DateTime? LastModificationTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? LastModifiedId { get; set; }
        public virtual UserAccounts LastModified { get; set; }
    }
    public class FullRootModel<Identity> : BasicRootModel<Identity>
    {
        [Column(TypeName = "timestamp without time zone")]
        public virtual DateTime? DeleteTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? DeletorId { get; set; }
        public virtual UserAccounts Deletor { get;}
        [Required]
        public bool IsDelete { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public virtual DateTime? LastModificationTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? LastModifiedId { get; set; }
        public virtual UserAccounts LastModified { get; set; }
    }
    public class RootIdentityModelWithoutCreator<Identity> : EntityIdentityModel<Identity>
    {
        [Required, Column(TypeName = "timestamp without time zone")]
        public virtual DateTime? CreationTime { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public virtual DateTime? LastModificationTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? LastModifiedId { get; set; }
        public virtual UserAccounts LastModified { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public virtual DateTime? DeleteTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? DeletorId { get; set; }
        public virtual UserAccounts Deletor { get;}
        [Required]
        public bool IsDelete { get; set; }

    }
}
