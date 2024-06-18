using IdentityServerOtel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityServerOpenTelemetry();
builder.Services.AddIdentityServer();

// This is required for spans to have display names containing the path (even when only using MapGet).
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseIdentityServer();
app.MapGet("/test/", () => "Hello World!");
app.MapControllers();
app.Run();
