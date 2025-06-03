using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mosu
{
    namespace mosu.HydraulicSystem
    {
        public class HydraulicSystemModel
        {
            public double z1 = 0.3;
            public double z2 = 0.1;

            public double alpha_in_1 = 0.0583;
            public double alpha_in_2 = 0.0583;
            public double alpha_12 = 0.05;
            public double alpha_out = 0.05;

            public double p_in_1_0 = 2, p_in_2_0 = 2, p_out_0 = 0.05;
            public double x_in_1_0 = Math.PI * Math.Pow(0.04, 2) / 4;
            public double x_in_2_0 = Math.PI * Math.Pow(0.03, 2) / 4;
            public double x_12_0 = Math.PI * Math.Pow(0.03, 2) / 4;
            public double x_out_0 = Math.PI * Math.Pow(0.02, 2) / 4;

            public double F1 = Math.PI * Math.Pow(0.2, 2) / 4;
            public double F2 = Math.PI * Math.Pow(0.25, 2) / 4;

            public void IncreaseOutlet() => x_out_0 *= 1.5;
            public void DecreaseOutlet() => x_out_0 *= 0.5;

            public void IncreaseFlow12() => x_12_0 *= 1.5;
            public void DecreaseFlow12() => x_12_0 *= 0.5;

            public void IncreaseIn1() => x_in_1_0 *= 1.5;
            public void DecreaseIn1() => x_in_1_0 *= 0.5;

            public void IncreaseIn2() => x_in_2_0 *= 1.5;
            public void DecreaseIn2() => x_in_2_0 *= 0.5;
            public void UpdateLevels(double dt)
            {
                // Calculate flows using square root of positive pressure differences

                double Q_in1 = 0;
                if (p_in_1_0 > z1)
                    Q_in1 = alpha_in_1 * x_in_1_0 * Math.Sqrt(p_in_1_0 - z1);

                double Q_in2 = 0;
                if (p_in_2_0 > z2)
                    Q_in2 = alpha_in_2 * x_in_2_0 * Math.Sqrt(p_in_2_0 - z2);

                double Q_12 = 0;
                if (z1 > z2)
                    Q_12 = alpha_12 * x_12_0 * Math.Sqrt(z1 - z2);
                else if (z2 > z1)
                    Q_12 = -alpha_12 * x_12_0 * Math.Sqrt(z2 - z1);

                double Q_out = 0;
                if (z2 > p_out_0)
                    Q_out = alpha_out * x_out_0 * Math.Sqrt(z2 - p_out_0);

    
                z1 += dt * (Q_in1 - Q_12) / F1;
                z2 += dt * (Q_in2 + Q_12 - Q_out) / F2;

                // Ensure levels are not negative
                if (z1 < 0) z1 = 0;
                if (z2 < 0) z2 = 0;
            }

        }
        public class PIRegulatorOptimizer
        {
            public double Kp { get; private set; } = 1.17; // Initial engineering value
            public double Ti { get; private set; } = 70.0; // Initial engineering value

            public List<double> Time = new List<double>();
            public List<double> Response = new List<double>();
            public List<double> Error = new List<double>();

            private const double dt = 0.01; // Simulation step
            private const double simTime = 10.0; // 10 seconds simulation

            private const double delay = 0.1; // 100ms delay
            private readonly int delaySteps = (int)(delay / dt);

            private double CalculateISE(List<double> errors)
            {
                return errors.Sum(e => e * e * dt);
            }

            private double CalculateMaxDeviation(List<double> errors)
            {
                return errors.Max(e => Math.Abs(e));
            }

            public (double ISE, double MaxDev) Simulate(double kp, double ti)
            {
                Queue<double> delayBuffer = new Queue<double>(Enumerable.Repeat(0.0, delaySteps));

                double integral = 0;
                double output = 0;
                double plant = 0;

                Time.Clear();
                Response.Clear();
                Error.Clear();

                for (double t = 0; t <= simTime; t += dt)
                {
                    double setpoint = 1.0;
                    double error = setpoint - plant;
                    integral += error * dt;
                    double control = kp * (error + integral / ti);

                    delayBuffer.Enqueue(control);
                    double delayedInput = delayBuffer.Dequeue();

                    double dPlant = (-plant + 0.302 * delayedInput);
                    plant += dt * dPlant;

                    Time.Add(t);
                    Response.Add(plant);
                    Error.Add(error);
                }

                double ise = CalculateISE(Error);
                double maxDev = CalculateMaxDeviation(Error);
                return (ise, maxDev);
            }

            public (double Kp, double Ti, double BestISE, double BestDev) Optimize()
            {
                double bestKp = Kp;
                double bestTi = Ti;

                double bestISE = double.MaxValue;
                double bestDev = double.MaxValue;

                double[] kpRange = { 0.5, 0.75, 1.0, 1.25, 1.5 };
                double[] tiRange = { 50, 70, 90, 110, 130 };

                foreach (var kp in kpRange)
                {
                    foreach (var ti in tiRange)
                    {
                        var (ise, dev) = Simulate(kp, ti);
                        if (ise < bestISE)
                        {
                            bestISE = ise;
                            bestDev = dev;
                            bestKp = kp;
                            bestTi = ti;
                        }
                    }
                }

                Kp = bestKp;
                Ti = bestTi;
                return (bestKp, bestTi, bestISE, bestDev);
            }
        }
    }

}
