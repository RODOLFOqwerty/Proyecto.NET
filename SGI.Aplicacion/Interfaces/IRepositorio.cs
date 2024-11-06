using Microsoft.VisualBasic;

namespace SGI.Aplicacion.Interfaces;

public interface IRepositorio<T>
{
    void Agregar(T entidad);
    void Eliminar(int id);
    T ObtenerPorId(int id);
    IEnumerable<T> Listar();
    void Modificar(T entidad);
    T BuscarPorAtributo(string atributo);
}
