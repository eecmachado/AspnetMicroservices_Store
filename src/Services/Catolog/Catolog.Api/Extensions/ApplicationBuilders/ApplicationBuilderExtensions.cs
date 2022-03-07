using CorrelationId;
using Serilog;

namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationExtensions
{
    public static void AddWebApplication(this WebApplication app)
    {
        app.UseCorrelationId();
        app.UseSerilogRequestLogging();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthorization();
        app.MapControllers();
    }
}