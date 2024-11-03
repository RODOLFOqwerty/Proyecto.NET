using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI.Aplicacion.Validaciones
{
    public class TransaccionValidacion : IValidacion<Transaccion>
    {
        public bool Validar(Transaccion transaccion)
        {
            try{
                if (transaccion.cantidad <= 0)
                {
                    throw new ValidacionException("La cantidad debe ser mayor que cero.");
                }
                return true;
            }catch(ValidacionException ex){
                Console.WriteLine($"Error en la validación del producto: {ex.Message}");
                return false;
                throw;
            }

            // Podes incluir validaciones adicionales por aca
        }
        
        public bool Validar(Transaccion transaccion, Producto producto)
        {
 
            try{
                if (producto == null)
                {
                    throw new ValidacionException("El producto no existe.");
                }else if((producto.stock-transaccion.cantidad<=0)&&(transaccion.tipotransaccion == TipoTransaccion.Salida)){
                    throw new ValidacionException("El stock es menor a 0");
                }
                return true;
            }catch(ValidacionException ex){
                Console.WriteLine($"Error en la validación del producto: {ex.Message}");
                return false;
                throw;
            }
        }
    }
}
