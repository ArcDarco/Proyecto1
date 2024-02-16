// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    //public class Program
    //{

        public class pago
        {
            public int NumeroDePago { get; set; }
            public int NumeroDeCaja { get; set; }
            public int TipoDeServico { get; set; }
            public string Fecha { get; set; }
            public string Hora { get; set; }
            public string Cedula { get; set; }
            public string Nombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string NumeroDeFactura { get; set; }
            public double MontoPagar { get; set; }
            public double MontoDeComision { get; set; }
            public double MontoDeducido { get; set; }
            public double PagoCliente { get; set; }
            public double Vuelto { get; set; }

        }

    class Persona
    {
        public int NumeroPago { get; }
        public string Fecha { get; }
        public string Hora { get; }
        public string Cedula { get; }
        public string Nombre { get; }
        public string Apellido1 { get; }
        public string Apellido2 { get; }
        public string MontoRecibo { get; }
        public string TipoDeServicio { get; }
        public string TipoServicio { get; }

        public Persona(int numeroDePago, string fecha, string hora, string cedula, string nombre, string primerApellido, string segundoApellido, string montoPagar, string tipoDeServicio)
        {
            NumeroPago = numeroDePago;
            Fecha = fecha;
            Hora = hora;
            Cedula = cedula;
            Nombre = nombre;
            Apellido1 = primerApellido;
            Apellido2 = segundoApellido;
            MontoRecibo = montoPagar;
            TipoDeServicio = tipoDeServicio;
        }
    }

    public class Program // clase para que los vectores lleguen a 10 posiciones maximo
    {
        static pago[] pagos = new pago[10];
        static int numpagos = 0;
        static List<Persona> personas = new List<Persona>();
        static int totalRegistros = 0;
        private static object tipoDeServicio;
        static void Main(string[] args)
        {
            List<string[]> personas = new List<string[]>();
            int opcion; // Menu principal donde debe elegir una de las 7 opciones. 
            do
            {
                Console.WriteLine("Menu principal");
                Console.WriteLine("1. Inicializar vectores");
                Console.WriteLine("2. Realizar Pago de Servicios");
                Console.WriteLine("3. Consultar Pagos Realizados");
                Console.WriteLine("4. Modificar Pagos");
                Console.WriteLine("5. Eliminar Pagos");
                Console.WriteLine("6. SubMenu Reportes");
                Console.WriteLine("7. Salir");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            InicializarVectores();
                            break;
                        case 2:
                            RealizarPagos();
                            break;
                        case 3:
                            ConsultarPagos();
                            break;
                        case 4:
                            ModificarPagos();
                            break;
                        case 5:
                            EliminarPago();
                            break;
                        case 6:
                            bool regresarAlMenuPrincipal = false;
                            do
                            {

                                MostrarSubMenu();

                                int opcionSubMenu = LeerEntero("Seleccione una opción del submenú: ");

                                switch (opcionSubMenu)
                                {
                                    case 1:
                                        VerTodosLosPagos(personas);
                                        break;
                                    case 2:
                                        VerPagosPorTipoDeServicio();
                                        break;
                                    case 3:
                                        VerPagosPorCodigoDeCaja();
                                        break;
                                    case 4:
                                        VerDineroComisionadoPorServicios();
                                        break;
                                    case 5:
                                        regresarAlMenuPrincipal = true;
                                        Console.WriteLine("Regresando al menu principal. . .\n");
                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida del submenú.\n");
                                        break;
                                }

                            } while (!regresarAlMenuPrincipal);

                            break;
                        case 7:
                            Console.WriteLine("Saliendo del Programa +" +
                                "Muchas Gracias...");
                            break;
                        default:
                            Console.WriteLine("Opcion invalida, por favor seleccione una opcion valida");
                            break;
                    }

                }
                else // En caso de que el usuario ponga una letra en la opcion seria invalid, le pide ingresar de nuevo un numero
                {
                    Console.WriteLine("Digito un numero Invalido, Por Favor ingrese un numero valido");
                }
            } while (opcion != 7);
        }

        static void InicializarVectores() // Inicializacion de vectores 0; 
        {
            pagos = new pago[10];
            numpagos = 0;
            Console.WriteLine("Los vectores fueron inicializados correctamente.");
        }

        static void RealizarPagos() // incluir pagos en caso de que el usuario lo desee, 
        {
            if (numpagos < 10)
            {
                Console.WriteLine("Ingrese los datos del Pago");
                Console.Write("Numero de Pago: ");
                int numeroDePago = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la Fecha en Formato (DD/MM/AAAA): ");
                string fecha = Console.ReadLine();
                Console.WriteLine("Ingrese la Hora: ");
                string hora = Console.ReadLine();
                Console.WriteLine("Ingrese el Numero de cedula");
                string cedula = Console.ReadLine();
                Console.WriteLine("Ingrese su nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese su primer apellido");
                string primerApellido = Console.ReadLine();
                Console.WriteLine("Ingrese su segundo apellido");
                string segundoApellido = Console.ReadLine();
                //Console.WriteLine("Seleccione el tipo de Servicio a pagar (1=Recibo de Luz, 2=Recibo Teléfono, 3=Recibo de Agua): ");
                //int tipoDeServicio = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el numero de factura que desea Cancelar");
                string numeroDeFactura = (Console.ReadLine());
                Console.WriteLine("Ingrese el monto total de la factura que desea Pagar");
                int montoPagar = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el monto con el que desea pagar");
                int pagoCliente = int.Parse(Console.ReadLine());
                Console.WriteLine("Seleccione el tipo de Servicio a pagar (1=Recibo de Luz, 2=Recibo Teléfono, 3=Recibo de Agua): \n");
                int tipoDeServicio = int.Parse(Console.ReadLine());

                if (tipoDeServicio > 1 && tipoDeServicio < 3)
                {
                    Console.WriteLine("Numero incorrecto, seleccione una opcion valida");
                }

                double montoDeComision;

                if (tipoDeServicio == 1)
                    montoDeComision = montoPagar * 0.04;
                else if (tipoDeServicio == 2)
                    montoDeComision = montoPagar * 0.055;
                else
                    montoDeComision = montoPagar * 0.0065;

                double montodeducido = montoPagar - montoDeComision;
                double vuelto = pagoCliente - montoPagar;

                pagos[numpagos] = new pago { NumeroDePago = numeroDePago, Fecha = fecha, Hora = hora, Cedula = cedula, Nombre = nombre, PrimerApellido = primerApellido, SegundoApellido = segundoApellido, TipoDeServico = tipoDeServicio, NumeroDeFactura = numeroDeFactura, MontoPagar = montoPagar, MontoDeComision = montoDeComision, MontoDeducido = montodeducido, Vuelto = vuelto, PagoCliente = pagoCliente, };
                numpagos++;
                Console.WriteLine("Pago Registrado, Muchas Gracias\n");

            }
            else
            {
                Console.WriteLine("No se pueden realizar mas pagos, llego al limite de pagos permitidos");
            }
        }

        static void ConsultarPagos()
        {
            Console.WriteLine("Ingrese el numero de pago a consultar\n");
            int numeroPago = int.Parse(Console.ReadLine());
            bool encontrado = false;
            foreach (var pago in pagos)
            {
                if (pago != null && pago.NumeroDePago == numeroPago)
                {
                    Console.WriteLine($"Numero de pago: {pago.NumeroDePago}");
                    Console.WriteLine();
                    Console.WriteLine($"Fecha: {pago.Fecha}                           Hora: {pago.Hora} ");
                    Console.WriteLine();
                    Console.WriteLine($"Cedula: {pago.Cedula}                         Nombre: {pago.Nombre}");
                    Console.WriteLine();
                    Console.WriteLine($"Apellido1: {pago.PrimerApellido}              Apellido2: {pago.SegundoApellido} ");
                    Console.WriteLine();
                    Console.WriteLine($"Tipo de servicio: {pago.TipoDeServico}          [1- Electricidad 2- Telefono 3- Agua] ");
                    Console.WriteLine();
                    Console.WriteLine($"Numero de Factura: {pago.NumeroDeFactura}       Monto de la factura a cancelar: {pago.MontoPagar}");
                    Console.WriteLine();
                    Console.WriteLine($"Monto de Comision: {pago.MontoDeComision}       Paga con: {pago.PagoCliente}");
                    Console.WriteLine();
                    Console.WriteLine($"Monto deducido: {pago.MontoDeducido}            Vuelto: {pago.Vuelto} \n");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Pago no encontrado"); // si el numero digitado es diferente al # de factura, no encuentra el pago a consultar. 
            }
        }

        static void ModificarPagos()
        {
            Console.WriteLine("Ingrese el numero de pago que desea modificar\n");
            int numeroPago = int.Parse(Console.ReadLine());
            bool encontrado = false;
            for (int i = 0; i < numpagos; i++)
            {
                if (pagos[i].NumeroDePago == numeroPago)
                {
                    int opcion;
                    do
                    {

                        Console.WriteLine("Seleccione la opcion que desea modificar");
                        Console.WriteLine("1- Cedula");
                        Console.WriteLine("2- Nombre");
                        Console.WriteLine("3- Primer Apellido");
                        Console.WriteLine("4- Segundo Apellido");
                        Console.WriteLine("5- Tipo de servicio");
                        Console.WriteLine("6- Numero de Factura");
                        Console.WriteLine("7- Monto total de la Factura");
                        Console.WriteLine("8- Monto con el que cancela pago");
                        Console.WriteLine("9- Salir\n");

                        if (int.TryParse(Console.ReadLine(), out opcion))
                        {
                            switch (opcion)
                            {
                                case 1:
                                    Console.Write("Numero de cedula: ");
                                    pagos[i].Cedula = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Write("Nombre: ");
                                    pagos[i].Nombre = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Primer Apellido: ");
                                    pagos[i].PrimerApellido = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("Segundo Apellido: ");
                                    pagos[i].SegundoApellido = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.Write("Tipo de Servicio: ");
                                    int tipoDeServico;
                                    double montoDeComision;
                                    if (!int.TryParse(Console.ReadLine(), out tipoDeServico))
                                    {
                                        Console.WriteLine("Selecciono una opcion incorrecta. Ingrese un numero entre 1 y 3");
                                        return;
                                    }
                                    pagos[i].TipoDeServico = tipoDeServico;

                                    if (tipoDeServico == 1)
                                        pagos[i].MontoDeComision = pagos[i].MontoPagar * 0.04;
                                    else if (tipoDeServico == 2)
                                        pagos[i].MontoDeComision = pagos[i].MontoPagar * 0.055;
                                    else
                                        pagos[i].MontoDeComision = pagos[i].MontoPagar * 0.0065;
                                    break;
                                case 6:
                                    Console.WriteLine("Numero de Factura");
                                    pagos[i].NumeroDeFactura = Console.ReadLine();
                                    break;
                                case 7:
                                    Console.WriteLine("Monto de la Factura");
                                    pagos[i].MontoPagar = int.Parse(Console.ReadLine());
                                    break;
                                case 8:
                                    Console.WriteLine("Monto con el que cancela");
                                    pagos[i].PagoCliente = int.Parse(Console.ReadLine());
                                    break;


                            }

                        }
                        else
                        {
                            Console.WriteLine("digito un numero invalido, por favor, ingrese un numero dentro del rango");
                        }

                        pagos[i].MontoDeducido = pagos[i].MontoPagar - pagos[i].MontoDeComision;
                        pagos[i].Vuelto = pagos[i].MontoPagar - pagos[i].PagoCliente;

                    } while (opcion != 9);

                }
            }

        }

        static void EliminarPago() // eliminar un pago, sera eliminado con base en el numero de pago
        {
            Console.WriteLine("Ingrese el numero de pago que desea eliminar: ");
            int numeroDepago = int.Parse(Console.ReadLine());
            bool encontrado = false;
            for (int i = 0; i < numpagos; i++) // ciclo for mientras el valor de i sea menor que numpagos el ciclo continuara ejecutandose
            {
                if (pagos[i].NumeroDePago == numeroDepago) // el dato ingresado tendra que ser igual == que el numero de pago para que sea ejecutado el ciclo 
                {
                    for (int j = i; j < numpagos - 1; j++)
                    {
                        pagos[j] = pagos[j + 1];// este bucle mueve los datos ingresados en el array pagos hacia la izquierda para poder eliminar al ultimo
                                                //pago del array
                    }
                    pagos[numpagos - 1] = null;
                    numpagos--;
                    Console.WriteLine(" Pago eliminado exitosamente "); // el pago fue eliminado correctamente.
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine(" Pago no encontrado "); // si el dato ingresado es diferente al numero de pago, no sera encontrado.
            }

        }

        //------------------------------------ Sub menu ---------------------------------------------------------------------------------------------------------------------------------------

        static void MostrarSubMenu()
        {
            Console.WriteLine("----------------- Submenú -----------------");
            Console.WriteLine("1. Ver todos los Pagos");
            Console.WriteLine("2. Ver Pagos por tipo de Servicio");
            Console.WriteLine("3. Ver Pagos por código de caja");
            Console.WriteLine("4. Ver Dinero Comisionado por servicios");
            Console.WriteLine("5. Regresar al Menú Principal\n");
        }


        static int LeerEntero(string mensaje)
        {
            int entero;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out entero))
                {
                    return entero;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero válido.");
                }
            }
        }

        static void VerTodosLosPagos(List<string[]> personas)
        {
            int totalRegistros = personas.Count;

            Console.WriteLine($"                          Sistema Pago de Servicios Publicos       " +
                                $"\n                              Reporte: Todos los pagos             " +
                                $"\n#Pago / Fecha / Hora de Pago / Cedula / Nombre / Apellido1 / Apellido2 / Monto del Recibo" +
                                $"\n==========================================================================================");
            foreach (var datosPersona in personas)
            {
                Console.WriteLine($"{datosPersona[1]} / {datosPersona[2]} / {datosPersona[3]} / {datosPersona[4]} / {datosPersona[5]} / {datosPersona[6]} / {datosPersona[7]} / {datosPersona[8]} / {datosPersona[9]} / {datosPersona[10]}");
            }
            if (pagos != null)
            {
                foreach (var pago in pagos)
                {
                    if (pago != null)
                    {

                        Console.WriteLine($"\n{pago.NumeroDePago} / {pago.Fecha}  /  {pago.Hora}  /    {pago.Cedula}  /  {pago.Nombre} / {pago.PrimerApellido} / {pago.SegundoApellido}  /  {pago.MontoPagar}" +
                                $"\n=========================================================================================="); //Error en esta linea
                                                                                                                                  //Imprime en consola, pero no continua porque pago == null

                        string[] datosPersona = { $"{pago.NumeroDePago} , {pago.Fecha}  ,  {pago.Hora}   ,  {pago.Cedula}  ,  {pago.Nombre} ,  {pago.PrimerApellido} , {pago.SegundoApellido} ,  {pago.MontoPagar}", };
                        personas.Add(datosPersona);

                    } //    break;
                }
            }
            else
            {
                Console.WriteLine("La lista de pagos está vacía.");
            }

            Console.WriteLine($"Total de registros: {totalRegistros}");
        }



        static void VerPagosPorTipoDeServicio()
        {
            // Solicitar al usuario que ingrese el tipo de servicio
            Console.Write("Ingrese el tipo de servicio: ");
            string tipoServicio = Console.ReadLine();

            // Mostrar encabezado del reporte
            Console.WriteLine($"--------------- Reporte de Pagos por Tipo de Servicio: {tipoServicio} -----------------------");
            Console.WriteLine("Numero de Pago / Fecha / Hora de Pago / Cedula / Nombre / Primer apellido / Segundo apellido / Monto del Recibo\n");

            // Mostrar cada persona que haya pagado por el tipo de servicio especificado
            foreach (var pago in pagos)
            {
                if (pago != null)
                {
                    Console.WriteLine($"{pago.NumeroDePago} / {pago.Fecha} / {pago.Hora} / {pago.Cedula} / {pago.Nombre} / {pago.PrimerApellido} / {pago.SegundoApellido} / {pago.MontoPagar}");
                }
            }
        }

        static void VerPagosPorCodigoDeCaja()
        {
            Console.WriteLine("pagos por código de caja.");
        }

        static void VerDineroComisionadoPorServicios()
        {
            Console.WriteLine("ver el dinero comisionado por servicios.");
        }


    }
}



