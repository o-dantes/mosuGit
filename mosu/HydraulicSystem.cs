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

                // Update tank levels based on net flows and cross-sectional areas
                z1 += dt * (Q_in1 - Q_12) / F1;
                z2 += dt * (Q_in2 + Q_12 - Q_out) / F2;

                // Ensure levels are not negative
                if (z1 < 0) z1 = 0;
                if (z2 < 0) z2 = 0;
            }

        }
    }

}
