using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram
{
    // Clase que orquesta el procesamiento (Principio de Inversión de Dependencias)
    public class CalculadoraDivision
    {
        private readonly IOperacionMatematica _operacion;

        public CalculadoraDivision(IOperacionMatematica operacion)
        {
            _operacion = operacion;
        }

        public string Calcular(string numero1, string numero2)
        {
            return _operacion.Ejecutar(numero1, numero2);
        }
    }
}
