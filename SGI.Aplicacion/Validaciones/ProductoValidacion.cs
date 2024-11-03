using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
namespace SGI.Aplicacion.Validaciones;

public class ProductoValidacion : IValidacion<Producto>
{
    public bool Validar(Producto producto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(producto.nombre))
            {
                throw new ValidacionException("El nombre del producto no puede estar vacío.");
            }

            if (producto.precioUnitario <= 0)
            {
                throw new ValidacionException("El precio unitario debe ser mayor a 0.");
            }

            if (producto.stock <= 0)
            {
                throw new ValidacionException("El stock disponible no puede ser negativo.");
            }
            return true;

        }
        catch (ValidacionException ex)
        {
            Console.WriteLine($"Error en la validación del producto: {ex.Message}");
            return false;
        }
    }
}
