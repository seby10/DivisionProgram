using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram
{
    // Clase para validar datos de entrada (Principio de Responsabilidad Única)
    public class ValidadorNumerico
    {
        public bool ValidarNumero(string numero)
        {
            if (string.IsNullOrEmpty(numero))
                return false;

            foreach (char c in numero)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
    }
}
