using Serilog;

public class ExceptionHandlingMiddleware

{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            //TODO: Log feilmeldingen i serilog
            Log.Error(ex, "Feil skjedde!!!");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("En feil oppstod på serveren. Prøv igjen senere." );
        }
    }
}