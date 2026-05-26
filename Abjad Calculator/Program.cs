using System;
using System.Windows.Forms;

namespace Abjad_Calculator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }
}
