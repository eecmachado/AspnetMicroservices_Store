namespace Catolog.Api.Configurations;

public class CorrelationConfiguration
{
    public const string Correlation = "Correlation";

    public string RequestHeader { get; set; } = string.Empty;

    public bool AddToLoggingScope { get; set; }

    public bool UpdateTraceIdentifier { get; set; }
}