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
        [Required]
        public virtual DateTime? CreationTime { get; set; }
    }
    public class BasicRootModel<Identity> : EntityModel<Identity>
    {
        [Required]
        public virtual DateTime? CreationTime { get; set; }
        [Required, Column(TypeName = "bigint")]
        public virtual long CreatorId { get; set; }
    }
    public class FullIdentityRootModel<Identity> : BasicIdentityRootModel<Identity>
    {
        public virtual long? DeleteTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? DeletorId { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? LastModifierId { get; set; }
    }
    public class FullRootModel<Identity> : BasicRootModel<Identity>
    {
        public virtual long? DeleteTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? DeletorId { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? LastModifierId { get; set; }
    }
    public class RootIdentityModelWithoutCreator<Identity> : EntityIdentityModel<Identity>
    {
        [Required]
        public virtual DateTime? CreationTime { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        [Column(TypeName = "bigint")]
        public virtual long? LastModifierId { get; set; }
    }
}
