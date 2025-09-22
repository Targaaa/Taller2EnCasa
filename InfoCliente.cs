public class InfoCliente
{ 
    public static void VerDireccionCliente(Pedido pedido)
    {
        Console.WriteLine($"Direccion: {pedido.Cliente}");
        if (pedido.Cliente.DatosReferenciasDireccion != null)
        {
            Console.WriteLine($"Referencias del domicilio: {pedido.Cliente.DatosReferenciasDireccion}");
        }
    }

    public static void VerDatosCliente(Pedido pedido)
    {
        Console.WriteLine($"Cliente: {pedido.Cliente.Nombre}");
        Console.WriteLine($"Direccion: {pedido.Cliente.Direccion}");
        Console.WriteLine($"Telefono: {pedido.Cliente.Telefono}");
    }
} 