using System.Collections.Generic;

namespace NumerologicalSystemCalculator.Core
{
    public interface INumerologicalSystem
    {
        Dictionary<char, int> Value { get; set; }
    }
}