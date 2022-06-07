namespace HoneyPot.Middlewares
{
    public static class EndlessStreamMiddlewareExtensions
    {
        public static IApplicationBuilder UseEndlessStream(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EndlessStream>();
        }
    }
}
