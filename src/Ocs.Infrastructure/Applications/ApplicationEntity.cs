using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ocs.Domain.Enums;

namespace Ocs.Infrastructure.Applications;

public class ApplicationEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [Column("Author")]
    public Guid AuthorId { get; set; }

    [Required]
    [Column("Activity")]
    public ActivityType ActivityType { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    
    [MaxLength(300)]
    public string? Description { get; set; }
    
    [Required]
    [MaxLength(1000)]
    public string? Outline { get; set; }
    
    public DateTimeOffset SubmittedAt { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public bool IsSubmitted { get; set; }
}