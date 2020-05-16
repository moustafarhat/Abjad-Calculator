using System;
using System.Windows.Forms;
using NumerologicalSystemCalculator.abjadSystem;

namespace Abjad_Calculator
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var abjad= new AbjadCalculator();

            var abjadValues = new AbjadValues();

            var calculatedValue = abjad.Calculator(textBox1.Text, abjadValues.Value);

            if (calculatedValue == 0 && !string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Enter only Arabic Alphapet", "Error", MessageBoxButtons.OK);
            }
            else
            {
                label1.Text = calculatedValue.ToString();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
