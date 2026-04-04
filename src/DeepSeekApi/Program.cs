using DeepSeekApi;
using DeepSeekApi.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration
        .MinimumLevel.Information()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
        .Enrich.FromLogContext());

builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("DeepSeekApi"));

var settings = builder.Configuration.GetSection("DeepSeekApi").Get<AppSettings>() ?? new AppSettings();

builder.Services.AddSingleton(sp =>
{
    var logger = sp.GetRequiredService<ILogger<DeepSeekClient>>();
    return new DeepSeekClient(logger, settings.StorageStatePath);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

var client = app.Services.GetRequiredService<DeepSeekClient>();
await client.InitializeAsync();
await client.EnsureLoggedInAsync();

app.Logger.LogInformation("DeepSeek API server starting on http://localhost:{Port}", settings.Port);
await app.RunAsync($"http://localhost:{settings.Port}");
