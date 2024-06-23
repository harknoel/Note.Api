using Note.Api.Models.Interface;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 

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