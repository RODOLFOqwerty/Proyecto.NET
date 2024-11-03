using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI;

public class Repositorio_Usuario : IRepositorio<Usuario>
{
    public void Agregar(Usuario usuario){

    }

    public void Eliminar(int id){

    }

    public Usuario ObtenerPorId(int id){
        return null;
    }

    public IEnumerable<Usuario> Listar(){
        return null;
    }

    public int ObtenerNuevoId(){
        return 1;
    }
}
