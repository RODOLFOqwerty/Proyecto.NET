using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Validaciones;
namespace SGI.Aplicacion.CasosdeUso

{
    public class CasoUsoAltaProducto(IRepositorio<Producto> _repositorio, IValidacion<Producto> _validador, IServicioAutorizacion _servicioAutorizacion)
    {
        public void Ejecutar(Producto producto, Usuario usuario)
        {
            try{
                if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaBaja)){
                    _validador.Validar(producto);
                    _repositorio.Agregar(producto);
                }
            }catch(ValidacionException ex){
                Console.WriteLine($"ERROR EN ALTA PRODUCTO POR {ex}");
            }
        }

    }
}
