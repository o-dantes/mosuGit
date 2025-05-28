using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mosu
{
    public class GaussSeidelOptimizer
    {
        private const double Epsilon = 1e-6;
        private const int MaxIterations = 1000;

        // Функція цілі
        private double I(double u1, double u2)
        {
            return 2 * u1 * u1 + 4 * u2 * u2 + u1 * u1 - 10 * u1 * u2 + u2;
        }

        // Часткові похідні для метода Гауса-Зейделя (градієнтний підхід)
        public (double u1, double u2, int iterations) Minimize(double u1, double u2)
        {
            int iter = 0;
            const double learningRate = 0.01;

            while (iter < MaxIterations)
            {
                double prevU1 = u1;
                double prevU2 = u2;

                // Оновлюємо u1, вважаючи u2 фіксованим
                double gradU1 = 6 * u1 - 10 * u2;
                u1 -= learningRate * gradU1;

                // Оновлюємо u2, вже з новим u1
                double gradU2 = 8 * u2 - 10 * u1 + 1;
                u2 -= learningRate * gradU2;

                if (Math.Abs(u1 - prevU1) < Epsilon && Math.Abs(u2 - prevU2) < Epsilon)
                    break;

                iter++;
            }

            return (u1, u2, iter);
        }

    }
}

