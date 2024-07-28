using Microsoft.EntityFrameworkCore;
using ClientSVH.PackagesDBCore;
using ClientSVH.DocsBodyCore;
using ClientSVH.DocsBodyCore.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//postgresql db
builder.Services.AddDbContext<PackagesDBContext>(
    options => 
    {
        options.UseNpgsql(configuration.GetConnectionString(nameof(PackagesDBContext)));
    }
    );
//mongodb
builder.Services.Configure<DocsBodyDBConnectionSettings>(
builder.Configuration.GetSection("MongoDBContext"));
builder.Services.AddSingleton<DocBodyServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
