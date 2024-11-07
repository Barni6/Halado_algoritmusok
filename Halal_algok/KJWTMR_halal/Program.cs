using System;
using System.Drawing;
using System.IO;
using System.Linq;
using KJWTMR_halal.FunctionApproximationProblem;
using KJWTMR_halal.ImageSegmentationProblem;
using KJWTMR_halal.TravellingSalesmanProblem;
using KJWTMR_halal.TravellingSalesmanProblem.KJWTMR_halal.TravellingSalesmanProblem;

namespace KJWTMR_halals
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TravellingSalesman
            //string inputFile = "cities15.txt";
            //int populationSize = 1000;
            //float mutationRate = 0.15f;
            //int generations = 2000;

            //var tsp = new TravellingSalesman();
            //tsp.LoadDistanceMatrixFromFile(inputFile);

            //var ga = new GeneticAlgorithm(tsp, populationSize, mutationRate);
            //var solution = ga.Solve(generations);

            //double bestObjective = ga.CalculateObjective(solution[0]);
            //Console.WriteLine($"Legjobb útvonal hossza: {bestObjective}");
            #endregion

            #region ImageSegmentation
            //string inputImagePath = "input_image.jpg";
            //string outputImagePath = "segmented_image.jpg";

            //ImageSegmentation segmentation = new ImageSegmentation(5);
            //segmentation.Segment(inputImagePath, outputImagePath);

            //Console.WriteLine("Képszegmentálás kész.");
            #endregion

            #region FunctionApproximation
            //int numParticles = 20;
            //int numIterations = 100;

            //double inertiaWeight = 0.3;
            //double c1 = 1.0;
            //double c2 = 1.0;

            //double[] bestParameters = FunctionApproximation.ApproximateFunctionWithPSO(numParticles, numIterations, inertiaWeight, c1, c2);

            //Console.WriteLine("Legjobb paraméterek:");
            //foreach (var param in bestParameters)
            //{
            //    Console.WriteLine(param);
            //}

            #endregion

            Console.ReadLine();
        }


    }
}
