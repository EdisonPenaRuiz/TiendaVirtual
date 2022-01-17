using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Client.Hubs;
using TiendaVirtual.Core.Interfaces;
using TiendaVirtual.Infrastruture.Data;
using TiendaVirtual.Infrastruture.Repositories;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

//Interfaces
builder.Services.AddTransient<ILoginRepository, LoginRepository>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddTransient<IPedidosRepository, PedidosRepository>();
builder.Services.AddTransient<IArticulosRepository, ArticulosRepository>();
builder.Services.AddTransient<IFormasPagosUsuarioRepository, FormasPagosUsuarios>();
builder.Services.AddTransient<ICuentaRepository, CuentasRepository>();
builder.Services.AddTransient<IMensajeriaRepository, MensajeriaRepository>();



//DBContext
builder.Services.AddDbContext<TiendaVirtualContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

//Coords
builder.Services.AddCors(cords => cords.AddPolicy(name:"WebApiPolice",
    cordsBuilds => cordsBuilds.AllowAnyOrigin().
    AllowAnyHeader().
    AllowAnyMethod().
    SetIsOriginAllowed((Host) => true))) ;




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRouting();
app.UseCors("WebApiPolice");

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();


//No funciona aun, problemas con cords
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<MensajeriaTiempoReal>("/MensajeriaTiempoReal");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); 


app.Run();
