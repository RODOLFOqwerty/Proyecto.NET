using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI;

public class CasoUsoIniciarSesion(IRepositorio<Usuario> _repositorio, ServicioLogin _serviciologin)
{
    public void Ejecutar(string Email, string Contraseña){
        Usuario usuario = _repositorio.BuscarPorAtributo(Email);
        if(!_serviciologin.ExisteUsuario(usuario,Contraseña)){
            throw new Exception("Uno de los datos ingresados es incorrecto");
        }
    }
}
