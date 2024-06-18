using Duende.IdentityServer;
using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace IdentityServerOtel;

public static class StartupExtensions
{
    public static void AddIdentityServerOpenTelemetry(this IServiceCollection services)
    {
        var builder = services.AddOpenTelemetry();
        builder.ConfigureResource(resourceBuilder => 
            resourceBuilder.AddService(
                serviceName: "IdentityServerOtel",
                serviceNamespace: "local",
                serviceVersion: "0.1.0"));
        
        builder.WithMetrics(m =>
        {
            m.AddAspNetCoreInstrumentation();
            m.AddMeter(Telemetry.ServiceName);
            m.AddOtlpExporter(ConfigureExporter);
        });

        builder.WithTracing(t =>
        {
            t.AddAspNetCoreInstrumentation();
            t.AddSource(IdentityServerConstants.Tracing.Basic);
            t.AddOtlpExporter(ConfigureExporter);
        });
    }

    private static void ConfigureExporter(OtlpExporterOptions options)
    {
        options.Endpoint = new Uri("http://localhost:4317");
        options.Protocol = OtlpExportProtocol.Grpc;
        options.ExportProcessorType = ExportProcessorType.Simple;
    }
}