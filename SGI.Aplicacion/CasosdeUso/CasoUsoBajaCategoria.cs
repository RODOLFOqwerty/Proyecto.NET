using SGI.Aplicacion.Entidades; 
using SGI.Aplicacion.Interfaces;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaCategoria(IRepositorio<Categoria> _repositorio, IRepositorio<Producto> _repositorioProducto, IServicioAutorizacion _servicioAutorizacion)
    {
        
        public void Ejecutar(int id, Usuario usuario)
        {
            _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaBaja);
           

            
            // Lógica para verificar si la categoría tiene productos asignados
            IEnumerable<Producto> lista = _repositorioProducto.Listar();
            if(!lista.Any(p => p.categoriaId == id)){
                _repositorio.Eliminar(id);
            }else{
                throw new ValidacionException("HAY PRODUCTOS ASIGNADOS A ESA CATEGORIA");
                //Console.WriteLine("ERROR");
            }
        }
    }
}
