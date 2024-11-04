using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoAltaCategoria(IRepositorio<Categoria> _repositorio, IServicioAutorizacion _servicioAutorizacion, IValidacion<Categoria> validador)
    {
        

    public void Ejecutar(Categoria categoria, Usuario usuario)
    {
        try{
            if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaBaja)){
                validador.Validar(categoria); // Validar la categoría antes de agregar
                _repositorio.Agregar(categoria); // Agregar la categoría al repositorio
            }

        }catch(ValidacionException ex){
            Console.WriteLine($"ERROR EN ALTA CATEGORIA POR {ex}");
        }
    }


    }
}
