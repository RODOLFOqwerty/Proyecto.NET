using SGI.Aplicacion.Entidades;

namespace SGI;

public class ServicioLogin
{
    public bool ExisteUsuario(Usuario? usuario, string Contraseña){
        if((usuario != null)&&(usuario.Contraseña == SistemaHashing.getHash(Contraseña))){
            return true;
        }else{
            return false;
        }
    }
}
