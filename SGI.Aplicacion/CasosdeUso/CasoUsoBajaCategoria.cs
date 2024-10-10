using SGI.Aplicacion.Entidades; 
using SGI.Aplicacion.Interfaces;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaCategoria
    {
        private readonly IRepositorio<Categoria> _repositorio;
        private readonly IRepositorio<Producto> _repositorioProducto;
        private readonly IServicioAutorizacion _servicioAutorizacion= new ServicioAutorizacion();

        public CasoUsoBajaCategoria(IRepositorio<Categoria> repositorio, IRepositorio<Producto> repositorioP)
        {
            _repositorio = repositorio;
            _repositorioProducto = repositorioP;
        }

        public void Ejecutar(int id, Usuario usuario)
        {
            _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaBaja);
           

            
            // Lógica para verificar si la categoría tiene productos asignados
            IEnumerable<Producto> lista = _repositorioProducto.Listar();
            if(!lista.Any(p => p.categoriaId == id)){
                _repositorio.Eliminar(id);
            }else{
                //throw new ValidacionException("HAY PRODUCTOS ASIGNADOS A ESA CATEGORIA");
                Console.WriteLine("ERROR");
            }
        }
    }
}
