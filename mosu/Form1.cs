using mosu.mosu.HydraulicSystem;
using System;
using System.Windows.Forms;

namespace mosu
{
    public partial class Form1 : Form
    {
        private HydraulicSystemModel model;
        private Timer timer;

        public Form1(HydraulicSystemModel sharedModel)
        {
            InitializeComponent();
            model = sharedModel;
            InitializeTimer();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTimer(); // Timer starts when form is fully loaded
        }
        private void InitializeTimer()
        {
            timer = new Timer { Interval = 100 }; // 100 ms
            timer.Tick += (s, e) =>
            {
                double dt = timer.Interval / 1000.0;
                model.UpdateLevels(dt);
                Console.WriteLine($"Z1 = {model.z1:F3}, Z2 = {model.z2:F3}");
            };
            timer.Start();
        }

        private void btnIncreaseOut_Click(object sender, EventArgs e)
        {
            model.IncreaseOutlet();
            LogValveState("Outlet", model.x_out_0);
        }

        private void btnDecreaseOut_Click(object sender, EventArgs e)
        {
            model.DecreaseOutlet();
            LogValveState("Outlet", model.x_out_0);
        }

        private void btnIncrease12_Click(object sender, EventArgs e)
        {
            model.IncreaseFlow12();
            LogValveState("Flow 1→2", model.x_12_0);
        }

        private void btnDecrease12_Click(object sender, EventArgs e)
        {
            model.DecreaseFlow12();
            LogValveState("Flow 1→2", model.x_12_0);
        }

        private void btnIncreaseIn2_Click(object sender, EventArgs e)
        {
            model.IncreaseIn2();
            LogValveState("Inlet 2", model.x_in_2_0);
        }

        private void btnDecreaseIn2_Click(object sender, EventArgs e)
        {
            model.DecreaseIn2();
            LogValveState("Inlet 2", model.x_in_2_0);
        }

        private void btnIncreaseIn1_Click(object sender, EventArgs e)
        {
            model.IncreaseIn1();
            LogValveState("Inlet 1", model.x_in_1_0);
        }

        private void btnDecreaseIn1_Click(object sender, EventArgs e)
        {
            model.DecreaseIn1();
            LogValveState("Inlet 1", model.x_in_1_0);
        }

        private void LogValveState(string label, double value)
        {
            Console.WriteLine($"{label} adjusted: {value:F5}");
            Console.WriteLine($"Z1 = {model.z1:F3}, Z2 = {model.z2:F3}");
        }
    }
}

