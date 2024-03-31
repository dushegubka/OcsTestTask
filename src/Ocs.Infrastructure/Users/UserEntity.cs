using System.ComponentModel.DataAnnotations;

namespace Ocs.Infrastructure.Users;

public class UserEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
}