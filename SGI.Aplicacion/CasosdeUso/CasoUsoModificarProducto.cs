using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoModificarProducto(IRepositorio<Producto> _repositorio, IValidacion<Producto> _validador, IServicioAutorizacion _servicioAutorizacion)
    {
        public void Ejecutar(Producto producto, Usuario usuario)
        {
            try{
                if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaModificacion)){
                    _validador.Validar(producto);
                    _repositorio.Modificar(producto);
                }else{
                    throw new PermisosException("El usuario no tiene los permisos");
                }
            }catch(Exception ex){
                Console.WriteLine($"ERROR EN MODIFICAR PRODUCTO {ex}");
            }

            
        }
    }
}
