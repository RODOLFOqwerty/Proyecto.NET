using SGI.Aplicacion;
using SGI.Aplicacion.Entidades;

namespace SGI;

public class Repositorio_Transaccion
{
       private readonly string filePath = "transacciones.txt";

    public void Agregar(Transaccion transaccion)
    {
        transaccion.id = ObtenerNuevoId();
        var linea = $"{transaccion.id},{transaccion.productoid},{transaccion.cantidad},{transaccion.tipo},{transaccion.fechatransaccion}";
        File.AppendAllLines(filePath, new[] { linea });
    }

    public Transaccion? ObtenerPorId(int id)
    {
        var lineas = File.ReadAllLines(filePath);
        var linea = lineas.FirstOrDefault(l => l.StartsWith(id.ToString()));
        return linea != null ? ConvertirATransaccion(linea) : null;
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
            tipo = (TipoTransaccion)Enum.Parse(typeof(TipoTransaccion), partes[3]),
            fechatransaccion = DateTime.Parse(partes[4])
        };
    }

    private int ObtenerNuevoId()
    {
        if (!File.Exists(filePath)) return 1;  
        var ultimaLinea = File.ReadAllLines(filePath).LastOrDefault();
        return ultimaLinea != null ? int.Parse(ultimaLinea.Split(',')[0]) + 1 : 1;
    }
}
