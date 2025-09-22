public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;
    private List<Pedido> pedidos;
    public string Nombre { get => nombre; }
    public string Telefono { get => telefono; }
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
    public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        pedidos = new List<Pedido>();
    }
    public int JornalACobrar()
    {
        
    }
    public bool AsignarPedido(int idCadete, Pedido pedido)
    {
        Cadete cadete = cadetes.FirstOrDefault(c => c.Id == idCadete);
        if (cadete != null)
        {
            cadete.AgregarPedido(pedido);
            return true;
        }
        return false;
    }
    public void CambiarEstadoPedido(int numero)
    {
        var cadeteQueTienePedidos = Cadetes.FirstOrDefault(p => p.Pedidos.Any(q => q.Numero == numero));
        if (cadeteQueTienePedidos != null)
        {
            bool salir = false;
            while (!salir)
            {

                Console.WriteLine("Que desea hacer con el pedido?");
                Console.WriteLine("1 Completar pedido");
                Console.WriteLine("2 Retirar pedido para ir a entregar");
                Console.WriteLine("3 Dar de baja el pedido");
                Console.WriteLine("4 Salir");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        cadeteQueTienePedidos.CompletarPedido(numero);
                        salir = true;
                        break;
                    case "2":
                        cadeteQueTienePedidos.RetirarPedido(numero);
                        salir = true;
                        break;
                    case "3":
                        cadeteQueTienePedidos.DarDeBajaPedido(numero);
                        salir = true;
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta. Presione cualquier tecla");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
    public void ReasignarPedido(int numero)
    {
        var cadeteConPedido = cadetes.FirstOrDefault(p => p.Pedidos.Any(q => q.Numero == numero));
        if (cadeteConPedido != null)
        {
            var cadetesDisponibles = cadetes.Where(p => p.Id != cadeteConPedido.Id).ToList();
            Console.WriteLine("Cadetes disponibles para reasignar:");

            foreach (var cadete in cadetesDisponibles)
            {
                Console.WriteLine($"Cadete:{cadete.Nombre},ID: {cadete.Id} ");
            }

            Pedido pedidoAReasignar = cadeteConPedido.DarDeBajaPedido(numero);
            Console.WriteLine("Seleccione el ID del cadete que desea para reasignar el pedido");
            int idElegido = int.Parse(Console.ReadLine());
            Cadete cadeteElegido = cadetesDisponibles.FirstOrDefault(p => p.Id == idElegido);
            
            if (cadeteElegido != null)
            {
                cadeteElegido.AgregarPedido(pedidoAReasignar);
                Console.WriteLine($"Pedido {numero} reasignado al cadete {cadeteElegido.Nombre}");
            }
            else
            {
                Console.WriteLine("ID inválido. No se realizó la reasignación.");
            }
        }
        else
        {
            Console.WriteLine("El numero ingresado es incorrecto o no existe tal pedido");
        }
    }
    public void Informe()
    {
        int totalesEnvios = 0;
        foreach (var cadete in cadetes)
        {
            float pago = cadete.JornalACobrar();
            Console.WriteLine($"{cadete.Nombre}-${pago}");
            totalesEnvios += cadete.CantidadPedidosCompletados();
        }
        float promedioEnviosPorCadete = totalesEnvios / cadetes.Count;
        Console.WriteLine($"Total envios: {totalesEnvios}");
        Console.WriteLine($"Promedio de envios por cadete: {promedioEnviosPorCadete}");
    }
}