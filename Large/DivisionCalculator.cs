using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionProgram.Large
{


    // Principio de inversión de dependencias: dependemos de abstracciones, no de implementaciones concretas

    public class DivisionCalculator
    {
        private readonly IMathOperation<BigNumber> divider;

        public DivisionCalculator(IMathOperation<BigNumber> divider)
        {
            this.divider = divider;
        }

        public BigNumber Calculate(BigNumber dividend, BigNumber divisor)
        {
            return divider.Execute(dividend, divisor);
        }
    }
}
