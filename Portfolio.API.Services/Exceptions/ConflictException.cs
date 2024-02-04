namespace Portfolio.API.Services.Exceptions
{
    public class ConflictException(string message) 
        : Exception(message)
    {
    }
}
