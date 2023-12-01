using FLOWFIT;
using flowfitapi.Infrastructure.Data;
using flowfitapi.Infrastructure.Repositories;
using Flowfitapi.Services.Features.Clientes;
using Flowfitapi.Services.Features.DetalleVentas;
using Flowfitapi.Services.Features.DevolucionesCancelaciones;
using Flowfitapi.Services.Features.Instructores;
using Flowfitapi.Services.Features.Membresias;
using Flowfitapi.Services.Features.PagosMembresias;
using Flowfitapi.Services.Features.Productos;
using Flowfitapi.Services.Features.Proveedores;
using Flowfitapi.Services.Features.Rutinas;
using Flowfitapi.Services.Features.Usuarios;
using Flowfitapi.Services.Features.Ventas;
using Flowfitapi.Services.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura la lectura del archivo appsettings.json antes de usar Configuration
var Configuration = builder.Configuration;

// Agregar servicios a contenedor de dependencias.
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddTransient<UsuarioRepository>();
builder.Services.AddScoped<InstructorService>();
builder.Services.AddTransient<InstructorRepository>();
builder.Services.AddScoped<RutinaService>();
builder.Services.AddTransient<RutinaRepository>();
builder.Services.AddScoped<ProveedorService>();
builder.Services.AddTransient<ProveedorRepository>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddTransient<ClienteRepository>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddTransient<ProductoRepository>();
builder.Services.AddScoped<VentaService>();
builder.Services.AddTransient<VentaRepository>();
builder.Services.AddScoped<DetalleVentaService>();
builder.Services.AddTransient<DetalleVentaRepository>();
builder.Services.AddScoped<DevolucionCancelacionService>();
builder.Services.AddTransient<DevolucionCancelacionRepository>();
builder.Services.AddScoped<MembresiaService>();
builder.Services.AddTransient<MembresiaRepository>();
builder.Services.AddScoped<PagoMembresiaService>();
builder.Services.AddTransient<PagoMembresiaRepository>();
// Configura la base de datos con la cadena de conexión
builder.Services.AddDbContext<flowfitapiDbContext>(
    options => {
        options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);

builder.Services.AddControllers();

// Configurar Swagger/OpenAPI sin restricciones de entorno
builder.Services.AddSwaggerGen();

// Agregar AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

var app = builder.Build();

// Configurar el canal de solicitudes HTTP.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
