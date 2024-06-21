using Note.Api.Models.Interface;

namespace Note.Api.Models;

public class Entry : IIdentifiable
{
    public required int Id {get; set;} 
    public required string Title {get; set;}
    public required string Content {get; set;}
    public required string Category {get; set;}
}