using System.Diagnostics;

public class PageNavigationAnalyzerMiddleware
{
    private readonly RequestDelegate _next;

    public PageNavigationAnalyzerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IPageNavigationAnalyzerService pageNavigationAnalyzerService)
    {
        var referer = context.Request.Headers["Referer"].ToString();
        var refererUri = referer.Length > 0 
            ? new Uri(referer).AbsolutePath 
            : "(external)";
        
        pageNavigationAnalyzerService.AddEdge(refererUri, context.Request.Path);

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