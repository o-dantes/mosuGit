using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mosu
{
    public class GaussSeidelSolver
    {
        public static double[] Solve(double[,] A, double[] b, double[] x0, double tolerance = 1e-6, int maxIterations = 1000)
        {
            int n = b.Length;
            double[] x = (double[])x0.Clone();
            double[] xPrev = new double[n];

            for (int iter = 0; iter < maxIterations; iter++)
            {
                Array.Copy(x, xPrev, n);

                for (int i = 0; i < n; i++)
                {
                    double sum = 0.0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j != i)
                            sum += A[i, j] * x[j];
                    }
                    x[i] = (b[i] - sum) / A[i, i];
                }

                // Compute norm of the difference vector
                double norm = 0.0;
                for (int i = 0; i < n; i++)
                    norm += Math.Pow(x[i] - xPrev[i], 2);

                if (Math.Sqrt(norm) < tolerance)
                    return x; // Converged
            }

            return null; // Did not converge
        }
    }
}


