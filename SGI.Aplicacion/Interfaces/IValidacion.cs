namespace SGI.Aplicacion.Interfaces;

public interface IValidacion<T>
{
    bool Validar(T entidad);
}
