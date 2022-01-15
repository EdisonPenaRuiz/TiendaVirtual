using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Core.Interfaces;
using TiendaVirtual.Infrastruture.Data;
using TiendaVirtual.Infrastruture.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//Interfaces
builder.Services.AddTransient<ILoginRepository, LoginRepository>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddTransient<IPedidosRepository, PedidosRepository>();
builder.Services.AddTransient<IArticulosRepository, ArticulosRepository>();


//DBContext
builder.Services.AddDbContext<TiendaVirtualContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

//Coords
builder.Services.AddCors(cords => cords.AddPolicy("WebAppiCors", cordsBuilds => cordsBuilds.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
