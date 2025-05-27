using mosu.mosu.HydraulicSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mosu
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var sharedModel = new HydraulicSystemModel();
            var form1 = new Form1(sharedModel);
            var chartForm = new MainForm(sharedModel);

            form1.Show();
            Application.Run(chartForm);
        }
    }
}

