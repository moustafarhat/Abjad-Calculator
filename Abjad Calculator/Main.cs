using System;
using System.Windows.Forms;
using NumerologicalSystemCalculator.Core;
using NumerologicalSystemCalculator.abjadSystem;

namespace Abjad_Calculator
{
    public partial class Main : Form
    {
        private AbjadCalculator _calculator;

        public Main()
        {
            InitializeComponent();
            _calculator = new AbjadCalculator(new AbjadValues());
        }

        private void Recalculate()
        {
            var result = _calculator.Calculate(inputTextBox.Text);
            resultLabel.Text = result.Value.ToString();

            if (result.UnknownCharacters.Count == 0)
            {
                statusLabel.Text = string.Empty;
            }
            else
            {
                statusLabel.Text = $"Ignored {result.UnknownCharacters.Count} unsupported character(s): " +
                                   string.Join(' ', result.UnknownCharacters);
            }
        }

        private void InputTextBox_TextChanged(object? sender, EventArgs e) => Recalculate();

        private void CalculateButton_Click(object? sender, EventArgs e) => Recalculate();

        private void CopyButton_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resultLabel.Text))
            {
                Clipboard.SetText(resultLabel.Text);
            }
        }

        private void SystemComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            INumerologicalSystem system = systemComboBox.SelectedIndex switch
            {
                1 => new PersianAbjadValues(),
                _ => new AbjadValues(),
            };
            _calculator = new AbjadCalculator(system);
            Recalculate();
        }
    }
}
