using Microsoft.Extensions.Primitives; // To use StringValues.

public class SecurityHeaders
{
    private readonly RequestDelegate next;

    public SecurityHeaders(RequestDelegate next)
    {
        this.next = next;
    }

    public Task Invoke(HttpContext context)
    {
        context.Response.Headers.Append(
            "super-secure", new StringValues("enables"));

        return next(context);
    }
}