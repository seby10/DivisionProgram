using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram
{
    public class InterfazConsola : IInterfazUsuario
    {
        public string SolicitarNumero(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        public void MostrarResultado(string resultado)
        {
            Console.WriteLine($"\nResultado de la división: {resultado}");
        }

        public void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {mensaje}");
            Console.ResetColor();
        }
    }
}
