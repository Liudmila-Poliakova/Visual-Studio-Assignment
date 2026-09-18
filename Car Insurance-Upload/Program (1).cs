// Program.cs
// Author: Liudmila Poliakova
// Academy of Learning College
// Entry point for the CarInsurance ASP.NET Core MVC application

using CarInsurance.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services to the application
builder.Services.AddControllersWithViews();

// Register the ApplicationDbContext with Entity Framework
// Uses SQL Server with the connection string from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Set the default route to point to the Insuree controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Insuree}/{action=Index}/{id?}");

app.Run();
