using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_halal.TravellingSalesmanProblem
{
    public class TravellingSalesman
    {
        public double[,] DistanceMatrix { get; private set; }

        public void LoadDistanceMatrixFromFile(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var lines = File.ReadAllLines(filePath);
            int size = lines.Length;
            DistanceMatrix = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                var parts = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < size; j++)
                {
                    DistanceMatrix[i, j] = int.Parse(parts[j]);
                }
            }
        }

        public double GetDistance(int city1, int city2)
        {
            return DistanceMatrix[city1, city2];
        }

        public double[] GetNearestNeighbors(int city)
        {
            var numberOfCities = GetNumberOfCities();
            var distances = new double[numberOfCities];
            for (int i = 0; i < numberOfCities; i++)
            {
                if (i != city)
                {
                    distances[i] = GetDistance(city, i);
                }
                else
                {
                    distances[i] = int.MaxValue;
                }
            }

            var nearestNeighbors = new List<double>();
            for (int i = 0; i < numberOfCities; i++)
            {
                if (distances[i] == distances.Min())
                {
                    nearestNeighbors.Add(i);
                }
            }

            return nearestNeighbors.ToArray();
        }

        public int GetNumberOfCities()
        {
            return DistanceMatrix.GetLength(0);
        }
    }

}
