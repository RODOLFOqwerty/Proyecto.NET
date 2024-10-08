namespace SGI.Aplicacion.Interfaces;

public interface IRepositorio<T>
{
    void Agregar(T entidad);
    void Eliminar(int id);
    T ObtenerPorId(int id);
    IEnumerable<T> Listar();
}
