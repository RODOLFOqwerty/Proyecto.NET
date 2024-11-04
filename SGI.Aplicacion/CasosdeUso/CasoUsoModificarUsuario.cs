using SGI.Aplicacion;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI;

public class CasoUsoModificarUsuario(IRepositorio<Usuario> _repositorio, IValidacion<Usuario> _validador,IServicioAutorizacion _servicioautorizacion)
{
    public void Ejecutar(Usuario usuario, Usuario usuariomodificar){
        try{
            if(_servicioautorizacion.PoseeElPermiso(usuario,Permiso.UsuarioModificacion)){
                _validador.Validar(usuario);
                _repositorio.Modificar(usuariomodificar);
            }
        }catch(Exception ex){
            Console.WriteLine($"ERROR EN MODIFICAR USUARIO POR {ex}");
        }

    }
}
