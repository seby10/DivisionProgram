using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram
{
    public interface IInterfazUsuario
    {
        string SolicitarNumero(string mensaje);
        void MostrarResultado(string resultado);
        void MostrarError(string mensaje);
    }
}
