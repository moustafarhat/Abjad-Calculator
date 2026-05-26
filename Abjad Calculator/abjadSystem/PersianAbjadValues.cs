using System.Collections.Generic;
using NumerologicalSystemCalculator.Core;

namespace NumerologicalSystemCalculator.abjadSystem
{
    /// <summary>
    /// Arabic Abjad with the four Persian letters mapped to their nearest Arabic equivalents
    /// (پ→ب=2, چ→ج=3, ژ→ز=7, گ→ك=20).
    /// </summary>
    public class PersianAbjadValues : INumerologicalSystem
    {
        private readonly AbjadValues _arabic = new();

        public IReadOnlyDictionary<char, int> Values => _arabic.Values;

        public char Normalize(char c) => c switch
        {
            'پ' => 'ب',
            'چ' => 'ج',
            'ژ' => 'ز',
            'گ' => 'ك',
            _ => _arabic.Normalize(c),
        };
    }
}
