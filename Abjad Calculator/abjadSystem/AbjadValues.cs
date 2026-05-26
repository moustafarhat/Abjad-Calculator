using System.Collections.Generic;
using NumerologicalSystemCalculator.Core;

namespace NumerologicalSystemCalculator.abjadSystem
{
    /// <summary>
    /// Classical Arabic Abjad (Hisāb al-Jummal), Mashriqī order.
    /// Persian-only letters (پ, چ, ژ, گ) are not included — use <see cref="PersianAbjadValues"/>.
    /// </summary>
    public class AbjadValues : INumerologicalSystem
    {
        public IReadOnlyDictionary<char, int> Values { get; }

        public AbjadValues()
        {
            Values = new Dictionary<char, int>
            {
                {'ا', 1},
                {'ب', 2},
                {'ج', 3},
                {'د', 4},
                {'ه', 5},
                {'و', 6},
                {'ز', 7},
                {'ح', 8},
                {'ط', 9},
                {'ي', 10},
                {'ك', 20},
                {'ل', 30},
                {'م', 40},
                {'ن', 50},
                {'س', 60},
                {'ع', 70},
                {'ف', 80},
                {'ص', 90},
                {'ق', 100},
                {'ر', 200},
                {'ش', 300},
                {'ت', 400},
                {'ث', 500},
                {'خ', 600},
                {'ذ', 700},
                {'ض', 800},
                {'ظ', 900},
                {'غ', 1000},
            };
        }

        /// <summary>
        /// Folds visual / orthographic variants onto the canonical Abjad letters.
        /// Hamzated alifs → ا, Persian yāʾ → ي, tāʾ marbūṭa → ه (common scholarly convention).
        /// </summary>
        public char Normalize(char c) => c switch
        {
            'أ' or 'إ' or 'آ' or 'ٱ' => 'ا',
            'ى' or 'ی' => 'ي',
            'ة' => 'ه',
            'ك' or 'ک' => 'ك',
            'ؤ' => 'و',
            'ئ' => 'ي',
            'ء' => 'ا',
            _ => c,
        };
    }
}
