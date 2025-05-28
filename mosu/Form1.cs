using mosu.mosu.HydraulicSystem;
using System;
using System.Windows.Forms;

namespace mosu
{
    public partial class Form1 : Form
    {
        private HydraulicSystemModel model;
        private Timer timer;

        // Нове для PID і режимів
        private PIDController pid = new PIDController(10, 0.5, 1);
        private bool isAutoMode = false;

        // Контролі для PID
        private NumericUpDown numKp;
        private NumericUpDown numKi;
        private NumericUpDown numKd;

        public Form1(HydraulicSystemModel sharedModel)
        {
            InitializeComponent();
            model = sharedModel;

            InitializeTimer();
            InitializeControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Таймер ініціалізовано в конструкторі, додатково не потрібно
        }

        private void InitializeTimer()
        {
            timer = new Timer { Interval = 100 }; // 100 мс
            timer.Tick += (s, e) =>
            {
                double dt = timer.Interval / 1000.0;

                if (isAutoMode)
                {
                    double setpoint = 1;
                    double error = setpoint - model.z1;
                    double control = pid.Update(error, dt);
                    double valveAdjustmentSpeed = 1;

                    // Базове керування вхід/вихід для бака 1
                    model.x_in_1_0 += control * valveAdjustmentSpeed * dt;
                    model.x_in_1_0 = Clamp(model.x_in_1_0, 0, 1);

                    model.x_out_0 -= control * valveAdjustmentSpeed * dt;
                    model.x_out_0 = Clamp(model.x_out_0, 0, 1);

                    // Додатково: регуляція потоку між баками
                    if (model.z1 > model.z2 + 0.05)
                    {
                        // Відкрити потік 1 → 2
                        model.x_12_0 += 0.5 * dt;
                    }
                    else if (model.z2 > model.z1 + 0.05)
                    {
                        // Закрити потік 1 → 2
                        model.x_12_0 -= 0.5 * dt;
                    }
                    model.x_12_0 = Clamp(model.x_12_0, 0, 1);

                    // Стабілізація рівня у другому баку для уникнення перетікання
                    if (model.z2 > 0.4)
                    {
                        model.x_out_0 += 0.3 * dt;
                    }
                }



                model.UpdateLevels(dt);

                Console.WriteLine($"Режим: {(isAutoMode ? "Авто" : "Ручний")}, Z1 = {model.z1:F3}, Z2 = {model.z2:F3}, Клапан виходу = {model.x_out_0:F3}");
            };
            timer.Start();
        }

        private void InitializeControls()
        {
            // NumericUpDown для Kp
            numKp = new NumericUpDown()
            {
                Minimum = 0,
                Maximum = 100,
                DecimalPlaces = 2,
                Increment = 0.1M,
                Value = 1,
                Left = 10,
                Top = 40,
                Width = 80
            };
            numKp.ValueChanged += (s, e) => pid.Kp = (double)numKp.Value;
            Controls.Add(numKp);
            Controls.Add(new Label() { Text = "Kp", Left = 95, Top = 42, Width = 30 });

            // NumericUpDown для Ki
            numKi = new NumericUpDown()
            {
                Minimum = 0,
                Maximum = 100,
                DecimalPlaces = 3,
                Increment = 0.01M,
                Value = 0,
                Left = 130,
                Top = 40,
                Width = 80
            };
            numKi.ValueChanged += (s, e) => pid.Ki = (double)numKi.Value;
            Controls.Add(numKi);
            Controls.Add(new Label() { Text = "Ki", Left = 215, Top = 42, Width = 30 });

            // NumericUpDown для Kd
            numKd = new NumericUpDown()
            {
                Minimum = 0,
                Maximum = 100,
                DecimalPlaces = 3,
                Increment = 0.01M,
                Value = 0,
                Left = 250,
                Top = 40,
                Width = 80
            };
            numKd.ValueChanged += (s, e) => pid.Kd = (double)numKd.Value;
            Controls.Add(numKd);
            Controls.Add(new Label() { Text = "Kd", Left = 335, Top = 42, Width = 30 });
        }

        // Функція Clamp для обмеження значень (альтернатива Math.Clamp)
        private double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            else if (value > max) return max;
            else return value;
        }

        // Всі ваші кнопки та методи без змін:

        private void btnIncreaseOut_Click(object sender, EventArgs e)
        {
            model.IncreaseOutlet();
            LogValveState("Клапан виходу", model.x_out_0);
        }

        private void btnDecreaseOut_Click(object sender, EventArgs e)
        {
            model.DecreaseOutlet();
            LogValveState("Клапан виходу", model.x_out_0);
        }

        private void btnIncrease12_Click(object sender, EventArgs e)
        {
            model.IncreaseFlow12();
            LogValveState("Потік 1→2", model.x_12_0);
        }

        private void btnDecrease12_Click(object sender, EventArgs e)
        {
            model.DecreaseFlow12();
            LogValveState("Потік 1→2", model.x_12_0);
        }

        private void btnIncreaseIn2_Click(object sender, EventArgs e)
        {
            model.IncreaseIn2();
            LogValveState("Вхід 2", model.x_in_2_0);
        }

        private void btnDecreaseIn2_Click(object sender, EventArgs e)
        {
            model.DecreaseIn2();
            LogValveState("Вхід 2", model.x_in_2_0);
        }

        private void btnIncreaseIn1_Click(object sender, EventArgs e)
        {
            model.IncreaseIn1();
            LogValveState("Вхід 1", model.x_in_1_0);
        }

        private void btnDecreaseIn1_Click(object sender, EventArgs e)
        {
            model.DecreaseIn1();
            LogValveState("Вхід 1", model.x_in_1_0);
        }

        private void LogValveState(string label, double value)
        {
            Console.WriteLine($"{label} змінено: {value:F5}");
            Console.WriteLine($"Z1 = {model.z1:F3}, Z2 = {model.z2:F3}");
        }

        private void btnMode_Click_1(object sender, EventArgs e)
        {
            isAutoMode = !isAutoMode;
            if (isAutoMode)
            {
                btnMode.Text = "Переключити на Ручний";
                lblMode.Text = "Режим: Авто";
                pid.Reset(); // скидання інтегралу для уникнення насичення
            }
            else
            {
                btnMode.Text = "Переключити на Авто";
                lblMode.Text = "Режим: Ручний";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var optimizer = new GaussSeidelOptimizer();
            var (u1, u2, iters) = optimizer.Minimize(2, 2); // початкові значення

            Console.WriteLine($"Мінімум досягнуто при: u1 = {u1:F4}, u2 = {u2:F4} за {iters} ітерацій.");
        }
    }
}


