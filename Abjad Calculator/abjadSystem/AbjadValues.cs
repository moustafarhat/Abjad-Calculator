using NumerologicalSystemCalculator.Core;

namespace NumerologicalSystemCalculator.abjadSystem
{
    using Abjad_Calculator;
    using System.Collections.Generic;

    public class AbjadValues : INumerologicalSystem
    {
        public Dictionary<char, int> Value { get; set; }

        public AbjadValues()
        {
            Value = new Dictionary<char, int>()

            {
                {'ا',1} ,
                {'آ',1} ,
                {'أ',1} ,
                {'ب',2} ,
                {'پ',2} ,
                {'ج',3} ,
                {'چ',3} ,
                {'د',4} ,
                {'ه',5} ,
                {'و',6} ,
                {'ز',7} ,
                {'ژ',7} ,
                {'ح',8} ,
                {'ط',9} ,
                {'ی',10} ,
                {'ى',10} ,
                {'ي',10} ,
                {'ك',20} ,
                {'ک',20} ,
                {'گ',20} ,
                {'ل',30} ,
                {'م',40} ,
                {'ن',50} ,
                {'س',60} ,
                {'ع',70} ,
                {'ف',80} ,
                {'ص',90} ,
                {'ق',100} ,
                {'ر',200} ,
                {'ش',300} ,
                {'ت',400} ,
                {'ث',500} ,
                {'خ',600} ,
                {'ذ',700} ,
                {'ض',800} ,
                {'ظ',900} ,
                {'غ',1000} ,
            };
        }
    }
}