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
        app.UseSwaggerUI(c=>c.SwaggerEndpoint("v1/swagger.json","Catalog.Api v1"));
        app.UseAuthorization();
        app.MapControllers();
    }
}