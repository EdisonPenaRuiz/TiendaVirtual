using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Core.Interfaces;
using TiendaVirtual.Infrastruture.Data;
using TiendaVirtual.Infrastruture.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
