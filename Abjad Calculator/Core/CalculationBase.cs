using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NumerologicalSystemCalculator.Core
{
    public readonly record struct CalculationResult(long Value, IReadOnlyList<char> UnknownCharacters)
    {
        public bool Success => UnknownCharacters.Count == 0;
    }

    public abstract class CalculationBase
    {
        private readonly INumerologicalSystem _system;

        protected CalculationBase(INumerologicalSystem system)
        {
            _system = system;
        }

        public CalculationResult Calculate(string? words)
        {
            if (string.IsNullOrWhiteSpace(words))
            {
                return new CalculationResult(0, Array.Empty<char>());
            }

            var prepared = Prepare(words);
            long total = 0;
            List<char>? unknown = null;

            foreach (var raw in prepared)
            {
                var ch = _system.Normalize(raw);
                if (_system.Values.TryGetValue(ch, out var value))
                {
                    total += value;
                }
                else
                {
                    (unknown ??= new List<char>()).Add(raw);
                }
            }

            return new CalculationResult(
                total,
                (IReadOnlyList<char>?)unknown ?? Array.Empty<char>());
        }

        // NFKD decomposes ligatures (e.g. ﻻ → ل+ا) and presentation forms back to base letters,
        // and separates combining marks (tashkīl) so they can be stripped.
        private static string Prepare(string input)
        {
            var decomposed = input.Normalize(NormalizationForm.FormKD);
            var sb = new StringBuilder(decomposed.Length);
            foreach (var c in decomposed)
            {
                if (char.IsWhiteSpace(c)) continue;
                if (c == 'ـ') continue; // tatweel (kashida)

                if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark)
                    continue; // tashkīl / harakat

                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
