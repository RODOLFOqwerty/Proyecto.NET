using SGI.Aplicacion.Entidades; 
using SGI.Aplicacion.Interfaces;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaCategoria(IRepositorio<Categoria> _repositorio, IRepositorio<Producto> _repositorioProducto, IServicioAutorizacion _servicioAutorizacion)
    {
        
        public void Ejecutar(int id, Usuario usuario)
        {
            if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaBaja)){
                if(_repositorioProducto.BuscarPorAtributo(id.ToString()) != null){
                    _repositorio.Eliminar(id);
                }else{
                    throw new ValidacionException("Hay productos asignados");
                }
            }else{
                throw new PermisosException("No pose los permisos");
            }
        }
    }
}
