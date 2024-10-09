using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI.Aplicacion.Validaciones
{
    public class TransaccionValidacion : IValidacion<Transaccion>
    {
        public void Validar(Transaccion transaccion)
        {
            if (transaccion.cantidad <= 0)
            {
                throw new ValidacionException("La cantidad debe ser mayor que cero.");
            }

            // Podes incluir validaciones adicionales por aca
        }
        
        public void Validar(Transaccion transaccion, Producto producto)
        {
 
            if (producto == null)
            {
                throw new ValidacionException("El producto no existe.");
            }else if((producto.stock<=0)&&(transaccion.tipotransaccion == TipoTransaccion.Salida)){
                throw new ValidacionException("El stock es menor a 0");
            }
        }
    }
}
