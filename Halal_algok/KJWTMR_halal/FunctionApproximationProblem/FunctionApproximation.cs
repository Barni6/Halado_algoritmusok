using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_halal.FunctionApproximationProblem
{
    public class FunctionApproximation
    {
        public static double TargetFunction(double x)
        {
            // Példa: lineáris függvény
            return 36 * x + 25;

            // Példa: Kvadratikus függvény
            //return 15 * x * x + 6 * x + 12;

            // Példa: Sin függvény
            //return Math.Sin(x); 
        }

        public static double EvaluateModel(double x, double[] parameters)
        {
            // Példa: lineáris modell (mx + b)
            return parameters[0] * x + parameters[1];

            // Kvadratikus modell (ax^2 + bx + c)
            //return parameters[0] * x * x + parameters[1] * x + parameters[2];


            // Példa: Trigonometrikus polinom (Fourier sorok alapú közelítés)
            //double result = parameters[0];
            //for (int n = 1; n < parameters.Length / 2; n++)
            //{
            //    result += parameters[2 * n - 1] * Math.Cos(n * x) + parameters[2 * n] * Math.Sin(n * x);
            //}
            //return result;
        }

        public static double[] ApproximateFunctionWithPSO(int numParticles, int numIterations, double inertiaWeight, double c1, double c2)
        {
            PSO pso = new PSO(numParticles, numIterations, inertiaWeight, c1, c2);
            return pso.Optimize();
        }

    }
}
