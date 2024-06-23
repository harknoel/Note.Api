using Note.Api.Models.Interface;
using System.ComponentModel.DataAnnotations; // For [Key] attribute
using System.ComponentModel.DataAnnotations.Schema; // For [DatabaseGenerated] attribute

namespace Note.Api.Models;

public class Entry : IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Category { get; set; }
}