using NumerologicalSystemCalculator.abjadSystem;
using Xunit;

namespace NumerologicalSystemCalculator.Tests
{
    public class AbjadCalculatorTests
    {
        [Theory]
        [InlineData("ا", 1)]
        [InlineData("ب", 2)]
        [InlineData("غ", 1000)]
        [InlineData("ابجد", 1 + 2 + 3 + 4)]
        [InlineData("هوز", 5 + 6 + 7)]
        [InlineData("حطي", 8 + 9 + 10)]
        [InlineData("كلمن", 20 + 30 + 40 + 50)]
        [InlineData("سعفص", 60 + 70 + 80 + 90)]
        [InlineData("قرشت", 100 + 200 + 300 + 400)]
        [InlineData("ثخذ", 500 + 600 + 700)]
        [InlineData("ضظغ", 800 + 900 + 1000)]
        [InlineData("محمد", 40 + 8 + 40 + 4)]
        public void Calculate_ClassicalAbjadOrder_ReturnsExpectedTotal(string input, long expected)
        {
            var calc = new AbjadCalculator();
            Assert.Equal(expected, calc.Calculate(input).Value);
        }

        [Theory]
        [InlineData("ا ب  ج", 1 + 2 + 3)]
        [InlineData("اـبـج", 1 + 2 + 3)]                          // tatweel
        [InlineData("مَحَمَّدٌ", 40 + 8 + 40 + 4)]                  // tashkīl
        [InlineData("أبجد", 1 + 2 + 3 + 4)]                      // hamza on alif
        [InlineData("آبجد", 1 + 2 + 3 + 4)]                      // alif madda
        [InlineData("علی", 70 + 30 + 10)]                         // Persian yāʾ → ي
        [InlineData("ﻻ", 30 + 1)]                                // lām-alif ligature
        [InlineData("فاطمة", 80 + 1 + 9 + 40 + 5)]                // tāʾ marbūṭa → ه
        public void Calculate_NormalizesOrthographicVariants(string input, long expected)
        {
            var calc = new AbjadCalculator();
            Assert.Equal(expected, calc.Calculate(input).Value);
        }

        [Fact]
        public void Calculate_EmptyOrNull_ReturnsZeroSuccess()
        {
            var calc = new AbjadCalculator();
            Assert.True(calc.Calculate(null).Success);
            Assert.Equal(0, calc.Calculate("").Value);
            Assert.Equal(0, calc.Calculate("   ").Value);
        }

        [Fact]
        public void Calculate_NonArabicCharacters_AreReportedNotThrown()
        {
            var calc = new AbjadCalculator();
            var result = calc.Calculate("abc محمد");
            Assert.False(result.Success);
            Assert.Equal(3, result.UnknownCharacters.Count);
            Assert.Equal(40 + 8 + 40 + 4, result.Value);
        }

        [Fact]
        public void PersianSystem_MapsPersianLettersToArabicEquivalents()
        {
            var calc = new AbjadCalculator(new PersianAbjadValues());
            // پ→2, چ→3, ژ→7, گ→20
            Assert.Equal(2 + 3 + 7 + 20, calc.Calculate("پچژگ").Value);
        }

        [Fact]
        public void DefaultArabicSystem_DoesNotAcceptPersianOnlyLetters()
        {
            var calc = new AbjadCalculator();
            var result = calc.Calculate("پ");
            Assert.False(result.Success);
            Assert.Single(result.UnknownCharacters);
            Assert.Equal(0, result.Value);
        }
    }
}
