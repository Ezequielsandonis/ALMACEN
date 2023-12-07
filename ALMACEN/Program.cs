using ALMACEN;
using ALMACEN.Models;
using ALMACEN.Models.DTOs;
using ALMACEN.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Enable API Explorer (if needed)
builder.Services.AddEndpointsApiExplorer();

// Configure Database Connection
builder.Services.AddDbContext<ALMACENContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

// Dependency Injection
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();

// AutoMapper Configuration
IMapper mapper = MappingConfiguration.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

// Additional Dependency
builder.Services.AddScoped<ResponseDto>();

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
