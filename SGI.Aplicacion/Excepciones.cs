using System;
namespace SGI.Aplicacion;

public class PermisosException : Exception
{
    public PermisosException(string mensaje) : base(mensaje) { }
}

public class RepositoriosException : Exception
{
    public RepositoriosException(string mensaje) : base(mensaje) {}
}

public class ValidacionException : Exception
{
    public ValidacionException(string mensaje) : base(mensaje) { }
}

public class StockInsuficienteException : Exception
{
    public StockInsuficienteException(string mensaje) : base(mensaje) { }
}
