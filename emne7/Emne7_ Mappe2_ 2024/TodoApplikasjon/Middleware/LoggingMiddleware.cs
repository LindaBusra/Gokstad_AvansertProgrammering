//Vi implementerer og bruker en LoggingMiddleware for å logge alle forespørsler til API-et.
public class LoggingMiddleware
{
    //Variable som holder referansen til neste middleware i serien
    private readonly RequestDelegate _next;     


    //Konstruktor som initialiserer LoggingMiddleware med RequestDelegate
    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;   
    }

    //Metode som blir kalt for hvert http-request

    public async Task InvokeAsync(HttpContext context)
    {
    //Logger detaljene for den inkommende requesten
    Console.WriteLine($"[{DateTime.Now}] Request: {context.Request.Method} {context.Request.Path}");

    //sender requesten videre til neste middleware
    await _next(context);
    
    //Logger detaljene for svaret eller response etter at neste middleware (controller) er ferdig
    Console.WriteLine($"[{DateTime.Now}] Response: {context.Response.StatusCode}");
    }
}