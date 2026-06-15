using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MultiModelContext>(item=>item.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
builder.Services.AddDbContext<UserdbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("constr2")));
builder.Services.AddDbContext<ProductdbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("constr3")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
