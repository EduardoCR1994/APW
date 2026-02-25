using APW.Business;
using APW.Data.MSSQL;
using APW.Data.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APW API", Version = "v1" });
});

builder.Services.AddSingleton<ProductDb2Context>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductBusiness, ProductBusiness>();

var app = builder.Build();

// Serve Swagger UI at application root ("/")
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APW API V1");
    c.RoutePrefix = string.Empty; // serve UI at root: https://localhost:5001/
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();