using Microsoft.EntityFrameworkCore;
using Midterm.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookManagementContext>(
    Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("BookManagementContext"))
    );

var app = builder.Build();

app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");




app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();

