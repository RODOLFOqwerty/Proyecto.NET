using SGI.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SGI.Repositorio;

public class GestorContext : DbContext
{
    #nullable disable
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Transaccion> Transacciones { get; set; }
    public DbSet<Categoria> Categorias { get; set;}
    public DbSet<Producto> Productos { get; set;}
    #nullable enable

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=gestor.sqlite");
    }
}
