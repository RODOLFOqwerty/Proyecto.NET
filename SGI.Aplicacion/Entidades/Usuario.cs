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
    public List<Permiso> Permisos { get; set; }

    public Usuario()
    {
        Permisos = new List<Permiso>();
    }

    public bool PoseePermiso(Permiso permiso)
    {
        return Permisos.Contains(permiso);
    }

    //ESTO ES UNA PRUEBA
    public void agregarTodosPermisos(){
        Permisos.Add(Permiso.CategoriaAlta);
        Permisos.Add(Permiso.ProductoAlta);
        Permisos.Add(Permiso.TransaccionAlta);
    }
    //....
    
}


