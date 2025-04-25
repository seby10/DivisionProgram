using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DivisionProgram;

namespace DivisionManual;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Programa de división manual de números grandes");
        Console.WriteLine("------------------------------------------------");

        try
        {
            // Solicitar el primer número
            Console.Write("Ingrese el dividendo A (hasta 150 dígitos): ");
            string dividendInput = Console.ReadLine();

            // Solicitar el segundo número
            Console.Write("Ingrese el divisor B (hasta 150 dígitos): ");
            string divisorInput = Console.ReadLine();

            // Crear los objetos BigNumber
            BigNumber dividend = new BigNumber(dividendInput);
            BigNumber divisor = new BigNumber(divisorInput);

            // Crear el calculador e inyectar la implementación de división
            DivisionCalculator calculator = new DivisionCalculator(new BigNumberDivider());

            // Realizar la división
            BigNumber result = calculator.Calculate(dividend, divisor);

            // Mostrar el resultado
            Console.WriteLine("\nResultado de la división:");
            Console.WriteLine($"{dividend} ÷ {divisor} = {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}