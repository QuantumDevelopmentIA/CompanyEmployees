using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

// Register AutoMapper with AutoMapper 16.x
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddMaps(typeof(Program).Assembly);
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());


// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CompanyEmployees.Infrastructure.Presentation.AssemblyReference).Assembly);


builder.Host.UseSerilog((hostContext, configuration) =>
{
    configuration.ReadFrom.Configuration(hostContext.Configuration);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
