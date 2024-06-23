namespace Note.Api.Exceptions;

public class NoEntryFoundException : Exception
{
    public NoEntryFoundException() : base("Entry not found") { }
}