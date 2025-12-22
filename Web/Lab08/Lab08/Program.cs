using Lab08.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
// 1. Namespaces
using Lab08.Repositories.Interfaces;       // Đảm bảo tên này khớp với tên Folder của bạn
using Lab08.Repositories.Implementations;
using Lab08.Services.Interfaces;
using Lab08.Services.Implementations;
using Lab08.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// =============================================================
// START: DI Container Registration
// =============================================================

// 1. Register Repositories
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();

// 2. Register Services
builder.Services.AddScoped<ICarModelService, CarModelService>();

// --- QUAN TRỌNG: THÊM DÒNG NÀY ĐỂ SỬA LỖI ---
builder.Services.AddScoped<ICarService, CarService>();
// =============================================================

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBrandService, BrandService>();
var app = builder.Build();

// ==========================================
// Database Seeding Logic
// ==========================================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    // db.Database.EnsureCreated(); 
    DbSeeder.Seed(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();