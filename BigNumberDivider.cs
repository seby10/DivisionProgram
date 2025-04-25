using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram

// Clase para división de números grandes (Principio de Responsabilidad Única)


{
    public class BigNumberDivider : IMathOperation<BigNumber>
    {
        private readonly BigNumberSubtractor subtractor;

        public BigNumberDivider()
        {
            subtractor = new BigNumberSubtractor();
        }

        public BigNumber Execute(BigNumber dividend, BigNumber divisor)
        {
            // Verificar división por cero
            if (divisor.IsEqualTo(new BigNumber("0")))
                throw new DivideByZeroException("No se puede dividir por cero");

            // Si el dividendo es menor que el divisor, el resultado es cero
            if (dividend.IsLessThan(divisor))
                return new BigNumber("0");

            // Dividir como lo haríamos a mano
            string result = "";
            BigNumber remainder = new BigNumber("0");

            // Convertir el dividendo a string para iterar por sus dígitos
            string dividendStr = dividend.ToString();

            for (int i = 0; i < dividendStr.Length; i++)
            {
                // Añadir el siguiente dígito al resto
                remainder = new BigNumber(remainder.ToString() + dividendStr[i]);

                // Encontrar cuántas veces cabe el divisor en el resto actual
                int quotientDigit = 0;
                while (remainder.IsGreaterOrEqualTo(divisor))
                {
                    remainder = subtractor.Execute(remainder, divisor);
                    quotientDigit++;
                }

                result += quotientDigit;
            }

            // Eliminar ceros no significativos al principio
            result = result.TrimStart('0');
            if (string.IsNullOrEmpty(result))
                result = "0";

            return new BigNumber(result);
        }
    }
}
