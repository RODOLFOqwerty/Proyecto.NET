using SGI.Aplicacion;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Repositorio;

namespace SGI;

public class Repositorio_Transaccion(GestorContext context):IRepositorio<Transaccion>
{
    public void Agregar(Transaccion transaccion)
    {
        context.Transacciones.Add(transaccion);
        context.SaveChanges();
    }

    public Transaccion ObtenerPorId(int id)
    {
        Transaccion? transaccion = context.Transacciones.Where(u => u.id == id).SingleOrDefault();
        if(transaccion == null){
            throw new ValidacionException("EL USUARIO NO FUE ENCONTRADO");
        }else{
            return transaccion;
        }
        
    }

    public IEnumerable<Transaccion> Listar()
    {
        return context.Transacciones.ToList() ?? new List<Transaccion>();
    }

    public void Eliminar(int id)
    {
        Transaccion? transaccion = context.Transacciones.Find(id);
        if(transaccion == null){
            throw new RepositoriosException("LA TRANSACCION NO FUE ENCONTRADA");
        }else{
            context.Transacciones.Remove(transaccion);
            context.SaveChanges();
        }
    }

    public void Modificar(Transaccion t){}

    public Transaccion BuscarPorAtributo(string atributo)
    {
        return context.Transacciones.First(t => t.productoid == Int32.Parse(atributo))??throw new RepositoriosException("La transaccion no fue encontrada");
    }

}
