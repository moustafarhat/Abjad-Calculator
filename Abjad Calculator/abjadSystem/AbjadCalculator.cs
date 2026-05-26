using NumerologicalSystemCalculator.Core;

namespace NumerologicalSystemCalculator.abjadSystem
{
    public class AbjadCalculator : CalculationBase
    {
        public AbjadCalculator() : base(new AbjadValues()) { }

        public AbjadCalculator(INumerologicalSystem system) : base(system) { }
    }
}
