using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mosu
{
    public class GaussOptimizer
    {
        private const double Epsilon = 1e-6;
        private const double h = 0.1;
        private const int MaxIterations = 1000;

        // Цільова функція (наприклад: ISE з PI-моделі)
        private Func<double, double, double> targetFunction;

        public GaussOptimizer(Func<double, double, double> function)
        {
            targetFunction = function;
        }

        public (double u1, double u2, double value, int iterations) Optimize(double u1Start, double u2Start)
        {
            double u1 = u1Start;
            double u2 = u2Start;
            int iter = 0;

            while (iter < MaxIterations)
            {
                double current = targetFunction(u1, u2);
                double best = current;
                double newU1 = u1;
                double newU2 = u2;

                // Пошук по u1
                double forwardU1 = targetFunction(u1 + h, u2);
                double backwardU1 = targetFunction(u1 - h, u2);
                if (forwardU1 < best)
                {
                    best = forwardU1;
                    newU1 = u1 + h;
                }
                else if (backwardU1 < best)
                {
                    best = backwardU1;
                    newU1 = u1 - h;
                }

                // Пошук по u2
                double forwardU2 = targetFunction(newU1, u2 + h);
                double backwardU2 = targetFunction(newU1, u2 - h);
                if (forwardU2 < best)
                {
                    best = forwardU2;
                    newU2 = u2 + h;
                }
                else if (backwardU2 < best)
                {
                    best = backwardU2;
                    newU2 = u2 - h;
                }

                // Перевірка зупинки
                if (Math.Abs(newU1 - u1) < Epsilon && Math.Abs(newU2 - u2) < Epsilon)
                    break;

                u1 = newU1;
                u2 = newU2;
                iter++;
            }

            return (u1, u2, targetFunction(u1, u2), iter);
        }
    }
}


