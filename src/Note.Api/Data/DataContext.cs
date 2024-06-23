using Note.Api.Models;
using Microsoft.EntityFrameworkCore;
using Note.Api.Models.Interface;
using Note.Api.Exceptions;

namespace Note.Api.Data;
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Entry> Entries => Set<Entry>();

    public async Task<T> FindItemById<T>(int id) where T : class, IIdentifiable
    {
        var item = await Set<T>().FindAsync(id);
        if (item == null && typeof(T) == typeof(Entry))
        {
            throw new NoEntryFoundException();
        }
        return item!;
    }
}