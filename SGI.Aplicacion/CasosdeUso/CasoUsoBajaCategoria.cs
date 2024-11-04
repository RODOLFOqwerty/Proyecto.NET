using SGI.Aplicacion.Entidades; 
using SGI.Aplicacion.Interfaces;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaCategoria(IRepositorio<Categoria> _repositorio, IRepositorio<Producto> _repositorioProducto, IServicioAutorizacion _servicioAutorizacion)
    {
        
        public void Ejecutar(int id, Usuario usuario)
        {
           try{
                if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaBaja)){
                IEnumerable<Producto> lista = _repositorioProducto.Listar();
                if(!lista.Any(p => p.categoriaId == id)){
                    _repositorio.Eliminar(id);
                }else{
                    throw new ValidacionException("HAY PRODUCTOS ASIGNADOS A ESA CATEGORIA");
                    //Console.WriteLine("ERROR");
                }
                }else{
                    throw new PermisosException("No pose los permisos");
                }
            }catch(Exception ex){
                Console.WriteLine($"ERROR EN BAJA DE CATEGORIA POR {ex}");
            }
           
        }
    }
}
