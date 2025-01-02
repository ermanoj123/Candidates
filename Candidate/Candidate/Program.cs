using Candidate.Context;
using Candidate.Repository;
using Candidate.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
//builder.Host.UseSerilog((context, configuration) =>
//{
//    configuration
//        .ReadFrom.Configuration(context.Configuration) // Read from appsettings.json
//        .Enrich.FromLogContext()
//        .MinimumLevel.Information()
//        .WriteTo.Console()
//        .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Minute)
//        .WriteTo.Seq("http://localhost:5341");
//});

// Add services to the container
builder.Services.AddDbContext<CandidateDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

try
{
    Log.Information("Application is starting");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}
