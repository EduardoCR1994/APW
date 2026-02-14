using APW.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDb>(opt =>opt.UseInMemoryDatabase("ProductList"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/products", async (ProductDb db) =>
    await db.Products.ToListAsync());


app.MapGet("/products/{id}", async (int id, ProductDb db) =>
    await db.Products.FindAsync(id)
        is Product product
            ? Results.Ok(product)
            : Results.NotFound());

app.MapPost("/products", async (Product product, ProductDb db) =>
{
    product.LastModified = DateTime.UtcNow;

    db.Products.Add(product);
    await db.SaveChangesAsync();

    return Results.Created($"/products/{product.ProductId}", product);
});

app.MapPut("/products/{id}", async (int id, Product input, ProductDb db) =>
{
    var product = await db.Products.FindAsync(id);

    if (product is null)
        return Results.NotFound();

    product.ProductName = input.ProductName;
    product.Description = input.Description;
    product.Rating = input.Rating;
    product.CategoryId = input.CategoryId;
    product.InventoryId = input.InventoryId;
    product.SupplierId = input.SupplierId;
    product.ModifiedBy = input.ModifiedBy;
    product.LastModified = DateTime.UtcNow;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/products/{id}", async (int id, ProductDb db) =>
{
    var product = await db.Products.FindAsync(id);

    if (product is null)
        return Results.NotFound();

    db.Products.Remove(product);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
