using Portfolio.API.Common.Constants;
using Portfolio.API.Data.Contracts;
using Portfolio.API.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Data.Entities
{
    public class User : IEntity, ISoftDelete
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        [MinLength(UserConstants.MinUsernameLength)]
        [MaxLength(UserConstants.MaxUsernameLength)]
        public required string UserName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(UserConstants.MinPasswordLength)]
        public required string Password { get; set; }

        [Required]
        [DefaultValue(Role.User)]
        public Role Role { get; set; } = Role.User;

        [Required]
        public required bool Active { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
