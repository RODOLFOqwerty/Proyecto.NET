using Microsoft.EntityFrameworkCore;
using SGI.Repositorio;

namespace SGI;

public class SQLite
{
    public void Inicializar(){
        using var context = new GestorContext();
        context.Database.EnsureCreated();
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }
    }
}
