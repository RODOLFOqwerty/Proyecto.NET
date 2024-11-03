using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI.Aplicacion.Validaciones;

public class CategoriaValidador : IValidacion<Categoria>
{
    public bool Validar(Categoria categoria)
    {
        if (string.IsNullOrWhiteSpace(categoria.nombre))
        {
            throw new ValidacionException("El nombre de la categoría no puede estar vacío.");
        }else{
            return true;
        }
    }
}
