public class PageNavigationAnalyzerMiddleware
{
    private readonly RequestDelegate _next;

    public PageNavigationAnalyzerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        await _next(context);
    }

}

public static class PageNavigationAnalyzerMiddlewareExtensions
{
    public static IApplicationBuilder UsePageNavigationAnalyzer(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<PageNavigationAnalyzerMiddleware>();
    }
}