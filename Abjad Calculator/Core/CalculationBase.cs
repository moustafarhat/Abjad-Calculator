using System;
using System.Collections.Generic;
using System.Linq;

namespace NumerologicalSystemCalculator.Core
{
    public abstract class CalculationBase
    {
        public virtual int Calculator(string words, Dictionary<char, int> alph)
        {
            try
            {
                var wordsWithoutWhitespace = RemoveWhitespace(words);

                return wordsWithoutWhitespace.Sum(t => alph[t]);
            }
            catch (Exception e)
            {
                // ignored
            }

            return 0;
        }

        private string RemoveWhitespace(string input)
        {
            if (input == null)
                return null;
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}