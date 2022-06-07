using System.Text;

namespace HoneyPot.Middlewares
{
    public class EndlessStream
    {
        private readonly RequestDelegate _next;
        private const string Message = "Not Found";
        private const int DelayMs = 5000;
        public EndlessStream(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var outputStream = context.Response.Body;
            while (true)
            {
                byte[] bytes = Encoding.ASCII.GetBytes($"{Message}{Environment.NewLine}");
                await outputStream.WriteAsync(bytes);
                await Task.Delay(DelayMs);
                await outputStream.FlushAsync();
            }
        }        
    }
}
