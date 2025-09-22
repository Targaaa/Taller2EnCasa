class GestorPedidos
{
    public static Pedido CrearPedido(int nroPedido)
    {
        string observacion;
        string nombreCliente;
        string direccionCliente;
        string telefonoCliente;
        string refCliente;
        do
        {
            Console.WriteLine("Ingrese el pedido:");
            observacion = Console.ReadLine();
            Console.WriteLine("Ingrese el cliente");
            nombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección");
            direccionCliente = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del cliente");
            telefonoCliente = Console.ReadLine();
            Console.WriteLine("Ingrese una referencia de la dirección: ");
            refCliente = Console.ReadLine();
        } while (string.IsNullOrEmpty(observacion) || string.IsNullOrEmpty(nombreCliente) || string.IsNullOrEmpty(direccionCliente) || string.IsNullOrEmpty(telefonoCliente));
        Pedido pedido1 = new Pedido(nroPedido, observacion, nombreCliente, direccionCliente, telefonoCliente, refCliente);
        return pedido1;
    }
    public static void MostrarPedido(Pedido pedido)
    {
        if (pedido != null)
        {
            Console.WriteLine($"Pedido N°: {pedido.Numero}");
            Console.WriteLine($"Observaciones: {pedido.Observacion}");
            Console.WriteLine($"Estado: {pedido.Estado}");
            InfoCliente.VerDatosCliente(pedido);
        }
        else
        {
            Console.WriteLine("No existe ese pedido");
        }
    }
    public static void MostrarPedidosSinEntregar(Cadeteria cadeteria)
    {
        foreach (var cadete in cadeteria.Cadetes)   //todos los cadetes de cadeteria
        {
            Console.WriteLine($"Cadete-{cadete.Nombre}");
            var pedidosSinEntregar = cadete.Pedidos.Where(p => p.Estado != Estados.Entregado).ToList(); //linq pedidos q no esten entregados
            if (pedidosSinEntregar.Count != 0)
            {
                foreach (var pedido in pedidosSinEntregar)  //pedidos encontrados sin entregar
                {
                    MostrarPedido(pedido);
                }
            }
            else
            {
                Console.WriteLine("El cadete no tiene pedidos sin entregar");
            }
        }
    }
    public static void MostrarPedidosQueAunNoSalieron(Cadeteria cadeteria)
    {
        foreach (var cadete in cadeteria.Cadetes)
        {
            var pedidosSinSalir = cadete.Pedidos.Where(p => p.Estado == Estados.Preparación).ToList();
            if (pedidosSinSalir.Count != 0)
            {
                foreach (var pedido in pedidosSinSalir)
                {
                    MostrarPedido(pedido);
                }
            }
            else
            {
                Console.WriteLine("No hay pedidos para retirar en el bar");
            }
        }
    }
}