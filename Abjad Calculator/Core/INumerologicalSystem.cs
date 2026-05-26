using System.Collections.Generic;

namespace NumerologicalSystemCalculator.Core
{
    public interface INumerologicalSystem
    {
        IReadOnlyDictionary<char, int> Values { get; }

        char Normalize(char c) => c;
    }
}
