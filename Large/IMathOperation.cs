using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram.Large
{
    // Interfaz para operaciones matemáticas (Principio de Segregación de Interfaces)
    public interface IMathOperation<T>
    {
        T Execute(T operand1, T operand2);
    }
}
