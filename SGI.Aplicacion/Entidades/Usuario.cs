namespace SGI.Aplicacion.Entidades;

public enum Permiso
{
    ProductoAlta,
    ProductoBaja,
    ProductoModificacion,
    CategoriaAlta,
    CategoriaBaja,
    CategoriaModificacion,
    TransaccionAlta,
    TransaccionBaja,
    UsuarioAlta,
    UsuarioBaja,
    UsuarioModificacion,
    AgregarCategoria
}

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } ="";
    public string Apellido { get; set;} ="";
    public string Email {get; set;} ="";
    public string Contraseña { get; set;} ="";
    public List<Permiso> Permisos { get; set; }

    public Usuario()
    {
        Permisos = new List<Permiso>();
    }
    
}


