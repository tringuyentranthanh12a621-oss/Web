using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Repositories.Interfaces;
using WebAPI.Repositories;
using WebAPI.Services;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// --- 1. Add Services ---
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
// Enable CORS (Allows your HTML page to talk to the API)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register your Repositories and Services here (from Step 5.6)
// builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
// builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// --- 2. Configure Pipeline ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// IMPORTANT: Add this to serve images from wwwroot/images
app.UseStaticFiles();

// IMPORTANT: Add this BEFORE Authorization
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// Seed Data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    // Ensure DataSeeder class exists in WebAPI.Data namespace
    DataSeeder.Seed(context);
}

app.Run();