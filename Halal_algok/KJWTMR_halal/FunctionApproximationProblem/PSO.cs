using System;
using System.Collections.Generic;

namespace KJWTMR_halal.FunctionApproximationProblem
{
    public class PSO
    {
        private int numParticles;
        private int numIterations;
        private double[] globalBestPosition;
        private double globalBestFitness = double.MaxValue;

        private double inertiaWeight;
        private double c1;
        private double c2;
        private double[][] pBest;
        private double[] gBest;

        private static Random rand = new Random();

        public PSO(int numParticles, int numIterations, double inertiaWeight, double c1, double c2)
        {
            this.numParticles = numParticles;
            this.numIterations = numIterations;
            this.inertiaWeight = inertiaWeight;
            this.c1 = c1;
            this.c2 = c2;

            pBest = new double[numParticles][];
            for (int i = 0; i < numParticles; i++)
            {
                pBest[i] = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    pBest[i][j] = double.MaxValue;
                }
            }

            gBest = new double[3];
            for (int i = 0; i < 3; i++)
            {
                gBest[i] = double.MaxValue;
            }
        }

        public double[] Optimize()
        {
            List<double[]> particles = InitializeParticles();
            for (int iteration = 0; iteration < numIterations; iteration++)
            {
                foreach (var particle in particles)
                {
                    UpdateParticlePosition(particle, pBest, gBest, inertiaWeight, c1, c2);
                    double fitness = CalculateFitness(particle);
                    UpdateGlobalBest(particle, fitness);
                }
            }
            return globalBestPosition;
        }

        private List<double[]> InitializeParticles()
        {
            List<double[]> particles = new List<double[]>();
            for (int i = 0; i < numParticles; i++)
            {
                double[] particle = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    particle[j] = rand.NextDouble() * 10 - 5;
                }
                particles.Add(particle);
            }
            return particles;
        }

        private void UpdateParticlePosition(double[] particle, double[][] pBest, double[] gBest, double inertiaWeight, double c1, double c2)
        {
            double[] velocity = new double[particle.Length];
            double vMax = 0.1 * (5 - (-5));

            for (int i = 0; i < particle.Length; i++)
            {
                velocity[i] = rand.NextDouble() * 0.1;
                double r1 = rand.NextDouble();
                double r2 = rand.NextDouble();

                velocity[i] = inertiaWeight * velocity[i] +
                              c1 * r1 * (pBest[i][i] - particle[i]) +
                              c2 * r2 * (gBest[i] - particle[i]);

                velocity[i] = Math.Clamp(velocity[i], -vMax, vMax);
                particle[i] += velocity[i];
            }
        }

        private double CalculateFitness(double[] particle)
        {
            double fitness = 0;
            for (double x = -5; x <= 5; x += 0.1)
            {
                double targetValue = FunctionApproximation.TargetFunction(x);
                double modelValue = FunctionApproximation.EvaluateModel(x, particle);
                fitness += Math.Pow(targetValue - modelValue, 2);
            }
            return fitness;
        }

        private void UpdateGlobalBest(double[] particle, double fitness)
        {
            if (fitness < globalBestFitness)
            {
                globalBestFitness = fitness;
                globalBestPosition = (double[])particle.Clone();
                for (int i = 0; i < particle.Length; i++)
                {
                    gBest[i] = particle[i];
                }
            }
        }
  
    }
}
