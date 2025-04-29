using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("División manual de números grandes (hasta 150 dígitos)");
            Console.WriteLine("====================================================");

            var validador = new ValidadorNumerico();
            var operacion = new DivisionManual(validador);
            var calculadora = new CalculadoraDivision(operacion);
            var ui = new InterfazConsola();

            int opcion;
            do
            {
                try
                {
                    string dividendo = ui.SolicitarNumero("Ingrese el dividendo (A): ");
                    string divisor = ui.SolicitarNumero("Ingrese el divisor (B): ");

                    string resultado = calculadora.Calcular(dividendo, divisor);

                    ui.MostrarResultado(resultado);
                }
                catch (Exception ex)
                {
                    ui.MostrarError(ex.Message);
                }

                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Continuar");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion) || (opcion != 1 && opcion != 2))
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    opcion = 0;
                }

            } while (opcion != 2);

            Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
        }
    }
}
