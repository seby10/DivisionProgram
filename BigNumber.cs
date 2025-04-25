using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram
{



    // Clase para representar números grandes (Principio de Responsabilidad Única)


    public class BigNumber
    {
        private List<int> digits;
        public bool IsNegative { get; private set; }

        public BigNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentException("El número no puede estar vacío", nameof(number));

            IsNegative = number.StartsWith("-");
            string absoluteValue = IsNegative ? number.Substring(1) : number;

            // Validar que todos los caracteres sean dígitos
            if (!absoluteValue.All(char.IsDigit))
                throw new ArgumentException("El número debe contener solo dígitos", nameof(number));

            // Almacenar los dígitos en orden inverso (del menos significativo al más significativo)
            digits = absoluteValue.Reverse().Select(c => int.Parse(c.ToString())).ToList();
            RemoveLeadingZeros();
        }

        // Constructor con lista de dígitos
        public BigNumber(List<int> digitList, bool isNegative = false)
        {
            digits = new List<int>(digitList);
            IsNegative = isNegative;
            RemoveLeadingZeros();
        }

        // Eliminar ceros no significativos
        private void RemoveLeadingZeros()
        {
            while (digits.Count > 1 && digits[digits.Count - 1] == 0)
                digits.RemoveAt(digits.Count - 1);
        }

        // Obtener un dígito en una posición específica
        public int GetDigitAt(int position)
        {
            return position < digits.Count ? digits[position] : 0;
        }

        // Número de dígitos
        public int Length => digits.Count;

        // Comparación de números
        public int CompareTo(BigNumber other)
        {
            if (IsNegative && !other.IsNegative) return -1;
            if (!IsNegative && other.IsNegative) return 1;

            int sign = IsNegative ? -1 : 1;

            if (Length != other.Length)
                return sign * (Length.CompareTo(other.Length));

            for (int i = Length - 1; i >= 0; i--)
            {
                if (digits[i] != other.digits[i])
                    return sign * (digits[i].CompareTo(other.digits[i]));
            }

            return 0; // Son iguales
        }

        public bool IsGreaterThan(BigNumber other) => CompareTo(other) > 0;
        public bool IsLessThan(BigNumber other) => CompareTo(other) < 0;
        public bool IsEqualTo(BigNumber other) => CompareTo(other) == 0;
        public bool IsGreaterOrEqualTo(BigNumber other) => CompareTo(other) >= 0;
        public bool IsLessOrEqualTo(BigNumber other) => CompareTo(other) <= 0;

        // Extrae un subnúmero desde la posición start hasta el final
        public BigNumber Substring(int start)
        {
            if (start >= Length) return new BigNumber("0");
            return new BigNumber(digits.GetRange(0, start), IsNegative);
        }

        // Extrae un subnúmero desde la posición start con length caracteres
        public BigNumber Substring(int start, int length)
        {
            if (start >= Length) return new BigNumber("0");
            int actualLength = Math.Min(length, Length - start);
            return new BigNumber(digits.GetRange(start, actualLength), IsNegative);
        }

        // Conversión a string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (IsNegative) sb.Append('-');
            for (int i = digits.Count - 1; i >= 0; i--)
                sb.Append(digits[i]);
            return sb.ToString();
        }
    }
}
