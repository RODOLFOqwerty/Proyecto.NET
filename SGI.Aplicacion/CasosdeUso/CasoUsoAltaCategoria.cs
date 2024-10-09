using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoAltaCategoria
    {
        private readonly IRepositorio<Categoria> _repositorio;
        
        public CasoUsoAltaCategoria(IRepositorio<Categoria> repositorio)
        {
            _repositorio = repositorio;
        }

    public void Ejecutar(Categoria categoria, Usuario usuario)
    {
        if (!usuario.PoseePermiso(Permiso.CategoriaAlta))
        {
            throw new PermisosException("El usuario no tiene permisos para dar de alta categorías.");
        }

        var validador = new CategoriaValidador();
        validador.Validar(categoria); // Validar la categoría antes de agregar

        _repositorio.Agregar(categoria); // Agregar la categoría al repositorio
    }


    }
}
