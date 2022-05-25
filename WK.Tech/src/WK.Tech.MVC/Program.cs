using Microsoft.EntityFrameworkCore;
using WK.Tech.Data;
using WK.Tech.Domain.AutoMapper;
using WK.Tech.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionMySql");
builder.Services.AddDbContext<CatalogContext>(o => o
 .UseMySql(builder.Configuration.GetConnectionString("DefaultConnectionMySql"), ServerVersion.AutoDetect(connectionString)));

builder.Services.ResolveDependencies();

builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
