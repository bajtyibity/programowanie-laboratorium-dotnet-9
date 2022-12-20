using MVC_LAB.Context;
using MVC_LAB.Models;
using Microsoft.EntityFrameworkCore;
using MVC_LAB.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersonContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PersonContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPersonService, PersonService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
