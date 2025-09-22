using System.Reflection.Metadata.Ecma335;

public class Menu
{
    //private int ultimoNumeroPedido;
    private HelperDeCSV helperCSV;
    private Cadeteria cadeteria;
    private GestorPedidos gestorPedidos;
    private List<Pedido> pedidosSinAsignar;
    private List<Cadete> cadetes;
    public Menu()
    {
        helperCSV = new HelperDeCSV();
        gestorPedidos = new GestorPedidos();
        pedidosSinAsignar = new List<Pedido>();
        cadetes = new List<Cadete>();
        IniciarCadeteria();
        InterfazUsuario();
    }
    private void IniciarCadeteria()
    {

        if (helperCSV.Existe("Cadetes.csv"))
        {
            cadetes = helperCSV.LeerCadetes("Cadetes.csv");
            Console.WriteLine($"Se cargaron {cadetes.Count} cadetes.");
        }
        else
        {
            Console.WriteLine("Error, archivo de cadetes no encontrado o vacio");
        }


        if (helperCSV.Existe("Cadeteria.csv"))
        {
            string infoCadeteria = helperCSV.LeerCadeteria("Cadeteria.csv");
            var datos = infoCadeteria.Split(';');
            cadeteria = new Cadeteria(datos[0], datos[1], cadetes);
        }
        else
        {
            Console.WriteLine("Archivo de cadetería no encontrado. Usando valores por defecto.");
            cadeteria = new Cadeteria("Cadetería Default", "123-456-789", cadetes);
        }
    }
    public void InterfazUsuario()
    {
        int nroPedido = 0;
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("==========MENU=========");
            Console.WriteLine($"Cadeteria {cadeteria.Nombre}");
            Console.WriteLine("1.Dar de alta un pedido");
            Console.WriteLine("2.Asignar pedido a un cadete");
            Console.WriteLine("3.Actualizar estado del pedido");
            Console.WriteLine("4.Reasignar pedido a otro cadete");
            Console.WriteLine("5.Informe");
            Console.WriteLine("6.Salir");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    nroPedido++;
                    Pedido pedidoNuevo = GestorPedidos.CrearPedido(nroPedido);
                    pedidosSinAsignar.Add(pedidoNuevo);
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    pedidoNuevo.Estado = Estados.Preparación;
                    break;

                case "2":
                    if (pedidosSinAsignar.Count == 0)
                    {
                        Console.WriteLine("No hay pedidos para asignar");
                        Console.WriteLine("Presione cualquier tecla para continuar");
                        Console.ReadKey();
                    }
                    else
                    {
                        foreach (var pedido in pedidosSinAsignar)
                        {
                            Console.WriteLine($"Pedido N°: {pedido.Numero} {pedido.Observacion}");
                        }

                        Console.WriteLine("Seleccione el número del pedido: ");
                        int numeroPedido = int.Parse(Console.ReadLine());
                        var pedidoAAsignar = pedidosSinAsignar.FirstOrDefault(p => p.Numero == numeroPedido);

                        if (pedidoAAsignar == null)
                        {
                            Console.WriteLine("Pedido no encontrado.");
                            Console.WriteLine("Presione cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Cadetes:");

                            foreach (var cadete in cadeteria.Cadetes)
                            {
                                Console.WriteLine($"ID: {cadete.Id}, nombre: {cadete.Nombre}");
                            }

                            
                            int idCadete = int.Parse(Console.ReadLine());
                            var cadeteAsignado = cadeteria.Cadetes.FirstOrDefault(q => q.Id == idCadete);
                            //esto no se guarda?
                            if (cadeteAsignado == null)
                            {
                                Console.WriteLine("Cadete no encontrado");
                            }
                            else
                            {
                                cadeteria.AsignarPedido(idCadete, pedidoAAsignar);
                                pedidosSinAsignar.RemoveAt(numeroPedido-1); //usar linq
                            }
                        }
                    }
                    break;
                case "3":
                    if (pedidosSinAsignar.Count == 0)
                    {
                        Console.WriteLine("No hay pedidos para cambiar el estado");
                        Console.WriteLine("Presione cualquier tecla para continuar");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Los pedidos a cambiar el estado son:");
                        GestorPedidos.MostrarPedidosSinEntregar(cadeteria);
                        Console.WriteLine("Seleccione el número del pedido: ");
                        int numeroSeleccionado = int.Parse(Console.ReadLine());
                        cadeteria.CambiarEstadoPedido(numeroSeleccionado);
                        Console.ReadKey();
                    }
                    break;
                case "4":
                    var pedidosAsignados = cadeteria.Cadetes.SelectMany(c => c.Pedidos).Where(p => p.Estado == Estados.Preparación).ToList();
                    if (pedidosAsignados.Count == 0)
                    {
                        Console.WriteLine("No hay pedidos asignados para reasignar");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Los pedidos que puede reasignar son:");
                        GestorPedidos.MostrarPedidosQueAunNoSalieron(cadeteria);
                        Console.WriteLine("Seleccione cual pedido quiere reasignar");
                        int numeroElegido = int.Parse(Console.ReadLine());
                        cadeteria.ReasignarPedido(numeroElegido);
                        Console.ReadKey();
                    }
                    break;
                case "5":
                    cadeteria.Informe();
                    break;
                case "6":
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