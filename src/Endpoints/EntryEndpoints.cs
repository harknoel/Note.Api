using Note.Api.Models.DTO;
using Note.Api.Models;
using Note.Api.Services;
using Note.Api.Exceptions;

namespace Note.Api.Endpoints;

public static class EntryEndpoint
{
    public static RouteGroupBuilder MapEntryEndpoint(this WebApplication app)
    {
        var route = app.MapGroup("/entries").WithTags("Note API").WithOpenApi();
        
        route.MapGet("/all", (EntryService entryService) => entryService.GetAllEntries());

        route.MapPost("/create",(EntryRequest entryrequest, EntryService entryService) => entryService.CreateEntry(entryrequest)); 

        route.MapGet("/get/{id}", (int id, EntryService entryService) => {
            try {
                Entry entry = entryService.GetEntryByID(id);
                return Results.Ok(entry);
            } catch (NoEntryFoundException ex) {
                return Results.NotFound(ex.Message);
            }
        });

        route.MapPost("/update/{id}", (int id, EntryRequest entryrequest, EntryService entryService) => {
            try {
                Entry OptionalEntry = entryService.UpdateEntryById(id, entryrequest);
                return Results.Ok(OptionalEntry);
            } catch(NoEntryFoundException ex) {
                return Results.NotFound(ex.Message);
            }
        });

        route.MapDelete("/delete/{id}", (int id, EntryService entryService) => {
            try {
                Entry entry = entryService.DeleteEntryById(id);
                return Results.Ok(entry);
            } catch(NoEntryFoundException ex) {
                return Results.NotFound(ex.Message);
            }
        });

        return route;
    }
    
}