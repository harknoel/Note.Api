using Note.Api.Models.Request;
using Note.Api.Models;
using Note.Api.Services;
using Note.Api.Exceptions;
using Note.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Note.Api.Endpoints;

public static class EntryEndpoint
{
    public static RouteGroupBuilder MapEntryEndpoint(this WebApplication app)
    {
        var route = app.MapGroup("/entries").WithTags("Note API").WithOpenApi();

        // route.MapGet("/all", (EntryService entryService) => entryService.GetAllEntries());

        // route.MapPost("/create",(EntryRequest entryrequest, EntryService entryService) => entryService.CreateEntry(entryrequest));

        // route.MapGet("/get/{id}", (int id, EntryService entryService) =>
        // {
        //     try
        //     {
        //         Entry entry = entryService.GetEntryByID(id);
        //         return Results.Ok(entry);
        //     }
        //     catch (NoEntryFoundException ex)
        //     {
        //         return Results.NotFound(ex.Message);
        //     }
        // });

        route.MapGet("/all", async (EntryService entryService) => await entryService.GetAllEntries());

        route.MapPost("/create",async (EntryService entryService, EntryRequest entryrequest) => await entryService.CreateEntry(entryrequest));

        route.MapGet("/get/{id}", async (int id, EntryService entryService) =>
        {
            try
            {
                Entry entry = await entryService.GetEntryByID(id);
                return Results.Ok(entry);
            }
            catch (NoEntryFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        }
        );

        route.MapPost("/update/{id}", async (int id, EntryRequest entryrequest, EntryService entryService) =>
        {
            try
            {
                Entry OptionalEntry = await entryService.UpdateEntryById(id, entryrequest);
                return Results.Ok(OptionalEntry);
            }
            catch (NoEntryFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        route.MapDelete("/delete/{id}", async (int id, EntryService entryService) =>
        {
            try
            {
                Entry entry = await entryService.DeleteEntryById(id);
                return Results.Ok(entry);
            }
            catch (NoEntryFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        return route;
    }

}