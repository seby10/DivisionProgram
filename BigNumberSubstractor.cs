using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram
{
    // Clase para resta de números grandes (Principio de Responsabilidad Única)

    public class BigNumberSubtractor : IMathOperation<BigNumber>
    {
        public BigNumber Execute(BigNumber a, BigNumber b)
        {
            // Si a < b, el resultado será negativo
            bool resultIsNegative = a.IsLessThan(b);
            BigNumber larger = resultIsNegative ? b : a;
            BigNumber smaller = resultIsNegative ? a : b;

            List<int> resultDigits = new List<int>();
            int borrow = 0;

            for (int i = 0; i < larger.Length; i++)
            {
                int difference = larger.GetDigitAt(i) - smaller.GetDigitAt(i) - borrow;
                if (difference < 0)
                {
                    difference += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
                resultDigits.Add(difference);
            }

            return new BigNumber(resultDigits, resultIsNegative);
        }
    }
}
