using SGI.UI.Components;
using SGI.Repositorio;
using SGI;
using SGI.Aplicacion.CasosdeUso;
using Microsoft.AspNetCore.DataProtection.Repositories;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion;

//inicio base de dato
SQLite sqlite = new SQLite();
GestorContext gestorContext = new GestorContext();
sqlite.Inicializar();

//prueba

Repositorio_Usuario repositorio_Usuario = new Repositorio_Usuario(gestorContext);
Usuario usuario = new Usuario();
usuario.Nombre = Console.ReadLine() ?? "";
usuario.Apellido = Console.ReadLine() ?? "";
usuario.Email = Console.ReadLine() ?? "";
usuario.Contraseña = Console.ReadLine() ?? "";

CasoUsoUsuarioAlta ua = new CasoUsoUsuarioAlta(repositorio_Usuario, new ServicioAutorizacion() ,new UsuarioValidacion());
Usuario adminTotal = new Usuario();
adminTotal.Permisos.Add(Permiso.UsuarioAlta);
ua.Ejecutar(adminTotal,usuario);

usuario.Nombre = Console.ReadLine() ?? "";
usuario.Apellido = Console.ReadLine() ?? "";
usuario.Email = Console.ReadLine() ?? "";
usuario.Contraseña = Console.ReadLine() ?? "";

ua.Ejecutar(adminTotal,usuario);
//
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
