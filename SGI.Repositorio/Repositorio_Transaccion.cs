using SGI.Aplicacion;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI;

public class Repositorio_Transaccion:IRepositorio<Transaccion>
{
       private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(),"Transacciones.txt");

    public void Agregar(Transaccion transaccion)
    {
        var linea = $"{transaccion.id},{transaccion.productoid},{transaccion.cantidad},{transaccion.tipotransaccion},{transaccion.fechatransaccion}";
        File.AppendAllLines(filePath, new[] { linea });
    }

    public Transaccion ObtenerPorId(int id)
    {
        var lineas = File.ReadAllLines(filePath);
        var linea = lineas.FirstOrDefault(l => l.StartsWith(id.ToString()));
        if (linea == null)
        {
            throw new KeyNotFoundException($"Producto con ID {id} no encontrado."); 
        }
        return ConvertirATransaccion(linea);
    }

    public IEnumerable<Transaccion> Listar()
    {
        if (!File.Exists(filePath))
            return new List<Transaccion>();  

        var lineas = File.ReadAllLines(filePath);
        return lineas.Select(ConvertirATransaccion).ToList();  
    }

    public void Eliminar(int id)
    {
        var lineas = File.ReadAllLines(filePath).Where(l => !l.StartsWith(id.ToString())).ToList();
        File.WriteAllLines(filePath, lineas);
    }

    private Transaccion ConvertirATransaccion(string linea)
    {
        var partes = linea.Split(',');
        return new Transaccion
        {
            id = int.Parse(partes[0]),
            productoid = int.Parse(partes[1]),
            cantidad = int.Parse(partes[2]),
            tipotransaccion = (TipoTransaccion)Enum.Parse(typeof(TipoTransaccion), partes[3]),
            fechatransaccion = DateTime.Parse(partes[4])
        };
    }

    public int ObtenerNuevoId()
    {
        if (!File.Exists(filePath)) return 1;  // Si no existe el archivo, empieza con ID 1.
        String[] lineas = File.ReadAllLines(filePath);
        if (lineas.Length==0) return 1;
        
        var ids = lineas.Select(lineas => int.Parse(lineas.Split(',')[0])).ToList();
        return ids.Max()+1;
    }
}
