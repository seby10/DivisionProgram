using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram;
public class DivisionManual : IOperacionMatematica
{
    private readonly ValidadorNumerico _validador;
    private readonly int _cantidadDecimales = 5;

    public DivisionManual(ValidadorNumerico validador)
    {
        _validador = validador;
    }

    public string Ejecutar(string dividendo, string divisor)
    {
        if (!_validador.ValidarNumero(dividendo) || !_validador.ValidarNumero(divisor))
            throw new ArgumentException("Los números deben contener solo dígitos");

        if (divisor == "0")
            throw new DivideByZeroException("No se puede dividir por cero");

        dividendo = EliminarCerosIzquierda(dividendo);
        divisor = EliminarCerosIzquierda(divisor);

        if (CompararNumeros(dividendo, divisor) < 0)
            return "0" + CalcularParteDecimal("0" + dividendo, divisor);

        return DividirManualmente(dividendo, divisor);
    }

    private string EliminarCerosIzquierda(string numero)
    {
        int i = 0;
        while (i < numero.Length - 1 && numero[i] == '0')
            i++;

        return numero.Substring(i);
    }

    private int CompararNumeros(string a, string b)
    {
        if (a.Length != b.Length)
            return a.Length.CompareTo(b.Length);

        return string.Compare(a, b);
    }

    private string DividirManualmente(string dividendo, string divisor)
    {
        StringBuilder resultado = new StringBuilder();
        string restoParcial = "";
        int posicion = 0;
        bool parteEntera = true;
        int contadorDecimales = 0;

        while (posicion < dividendo.Length || contadorDecimales < _cantidadDecimales)
        {
            if (posicion >= dividendo.Length && parteEntera)
            {
                resultado.Append('.');
                parteEntera = false;
            }

            if (posicion < dividendo.Length)
            {
                restoParcial += dividendo[posicion];
                posicion++;
            }
            else
            {
                restoParcial += '0';
                contadorDecimales++;
            }

            restoParcial = EliminarCerosIzquierda(restoParcial);


            if (CompararNumeros(restoParcial, divisor) < 0)
            {
                if (resultado.Length > 0 || posicion == dividendo.Length || !parteEntera)
                    resultado.Append('0');

                continue;
            }

            int digitoResultado = 0;
            string restoTemporal = restoParcial;

            while (CompararNumeros(restoTemporal, divisor) >= 0)
            {
                restoTemporal = RestarNumeros(restoTemporal, divisor);
                digitoResultado++;
            }

            resultado.Append(digitoResultado);

            restoParcial = restoTemporal;

            if (!parteEntera && restoParcial == "0")
                break;
        }

        string resultadoFinal = resultado.Length == 0 ? "0" : resultado.ToString();

        if (!resultadoFinal.Contains('.'))
        {
            resultadoFinal += CalcularParteDecimal("0", divisor);
        }

        return resultadoFinal;
    }

    private string CalcularParteDecimal(string dividendo, string divisor)
    {
        StringBuilder parteDecimal = new StringBuilder(".");
        string restoParcial = dividendo;

        for (int i = 0; i < _cantidadDecimales; i++)
        {
            restoParcial += "0";

            if (restoParcial == "0")
            {
                parteDecimal.Append(new string('0', _cantidadDecimales - i));
                break;
            }

            restoParcial = EliminarCerosIzquierda(restoParcial);

            if (CompararNumeros(restoParcial, divisor) < 0)
            {
                parteDecimal.Append('0');
                continue;
            }

            int digitoDecimal = 0;
            string restoTemporal = restoParcial;

            while (CompararNumeros(restoTemporal, divisor) >= 0)
            {
                restoTemporal = RestarNumeros(restoTemporal, divisor);
                digitoDecimal++;
            }

            parteDecimal.Append(digitoDecimal);

            restoParcial = restoTemporal;

            if (restoParcial == "0")
            {
                parteDecimal.Append(new string('0', _cantidadDecimales - i - 1));
                break;
            }
        }

        return parteDecimal.ToString();
    }

    private string RestarNumeros(string a, string b)
    {
        if (CompararNumeros(a, b) < 0)
            throw new ArgumentException("El primer número debe ser mayor o igual que el segundo");

        while (b.Length < a.Length)
            b = "0" + b;

        StringBuilder resultado = new StringBuilder();
        int prestamo = 0;

        for (int i = a.Length - 1; i >= 0; i--)
        {
            int digitoA = a[i] - '0';
            int digitoB = b[i] - '0';

            int diferencia = digitoA - digitoB - prestamo;

            if (diferencia < 0)
            {
                diferencia += 10;
                prestamo = 1;
            }
            else
            {
                prestamo = 0;
            }

            resultado.Insert(0, diferencia);
        }

        return EliminarCerosIzquierda(resultado.ToString());
    }
}