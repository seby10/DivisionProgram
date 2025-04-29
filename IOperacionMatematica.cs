using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram;

// Interfaz para operaciones matemáticas (Principio de Segregación de Interfaces)
public interface IOperacionMatematica
{
    string Ejecutar(string numero1, string numero2);
}
