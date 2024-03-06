using DemoBlazor.Data.Models;
using DemoBlazor.Models.DTO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NorthwindContext>(
    options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("NorthwindConnection"));
    });

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

var categories = app.MapGroup("/categories");

categories.MapGet("/", GetCategories);
categories.MapGet("/{id}", async (NorthwindContext context, int id) =>
{
    var category = await context.Categories.FindAsync(id);
    if (category == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(category);
});
categories.MapPost("/", async (NorthwindContext context, CategoryCreateDTO category) => {
    var newCategory = new Category
    {
        CategoryName = category.Name,
        Description = category.Description
    };
    await context.Categories.AddAsync(newCategory);
    await context.SaveChangesAsync();
    return Results.Created($"/categories/{newCategory.CategoryId}", newCategory);
});




app.Run();

async Task<IResult> GetCategories(NorthwindContext database)
{
    var categories = await database.Categories
             .Select(c => new CategoryDTO
             {
                 Id = c.CategoryId,
                 Name = c.CategoryName,
                 Description = c.Description
             })
             .ToListAsync();
    return Results.Ok(categories);
}
