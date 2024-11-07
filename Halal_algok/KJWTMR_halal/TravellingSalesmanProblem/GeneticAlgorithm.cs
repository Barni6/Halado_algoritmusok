using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_halal.TravellingSalesmanProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace KJWTMR_halal.TravellingSalesmanProblem
    {
        public class GeneticAlgorithm
        {
            private readonly TravellingSalesman problem;
            private readonly int populationSize;
            private readonly float mutationRate;
            private readonly Random rng;

            public GeneticAlgorithm(TravellingSalesman problem, int populationSize, float mutationRate)
            {
                this.problem = problem;
                this.populationSize = populationSize;
                this.mutationRate = mutationRate;
                this.rng = new Random();
            }

            public List<List<int>> Solve(int generations)
            {
                var population = InitializePopulation(populationSize);
                for (int i = 0; i < generations; i++)
                {
                    var parents = SelectParents(population);
                    var offspring = Crossover(parents);
                    Mutate(offspring);
                    population = SelectSurvivors(population, offspring);
                }
                return population;
            }

            private List<List<int>> InitializePopulation(int size)
            {
                var population = new List<List<int>>();
                for (int i = 0; i < size; i++)
                {
                    var route = Enumerable.Range(0, problem.GetNumberOfCities()).ToList();
                    Shuffle(route);
                    population.Add(route);
                }
                return population;
            }

            private void Shuffle<T>(List<T> list)
            {
                int n = list.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    T value = list[k];
                    list[k] = list[n];
                    list[n] = value;
                }
            }

            private List<List<int>> SelectParents(List<List<int>> population)
            {
                var parents = new List<List<int>>();
                var sortedPopulation = population.OrderBy(r => CalculateObjective(r)).ToList();
                parents.Add(sortedPopulation[0]);
                parents.Add(sortedPopulation[1]);
                return parents;
            }

            private List<List<int>> Crossover(List<List<int>> parents)
            {
                var offspring = new List<List<int>>();
                var parent1 = parents[0];
                var parent2 = parents[1];
                int crossoverPoint1 = rng.Next(1, parent1.Count - 1);
                int crossoverPoint2 = rng.Next(crossoverPoint1 + 1, parent1.Count);

                var child1 = parent1.Take(crossoverPoint1).Concat(parent2.Skip(crossoverPoint1).Take(crossoverPoint2 - crossoverPoint1)).Concat(parent1.Skip(crossoverPoint2)).ToList();
                var child2 = parent2.Take(crossoverPoint1).Concat(parent1.Skip(crossoverPoint1).Take(crossoverPoint2 - crossoverPoint1)).Concat(parent2.Skip(crossoverPoint2)).ToList();

                offspring.Add(child1);
                offspring.Add(child2);
                return offspring;
            }

            private void Mutate(List<List<int>> population)
            {
                foreach (var route in population)
                {
                    if (rng.NextDouble() < mutationRate)
                    {
                        int index1 = rng.Next(route.Count);
                        int index2 = rng.Next(route.Count);
                        Swap(route, index1, index2);
                    }
                }
            }

            private void Swap<T>(List<T> list, int index1, int index2)
            {
                T temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
            }

            private List<List<int>> SelectSurvivors(List<List<int>> population, List<List<int>> offspring)
            {
                var allRoutes = new List<List<int>>();
                allRoutes.AddRange(population);
                allRoutes.AddRange(offspring);
                var sortedRoutes = allRoutes.OrderBy(r => CalculateObjective(r)).ToList();
                return sortedRoutes.Take(populationSize).ToList();
            }

            public double CalculateObjective(List<int> route)
            {
                double totalDistance = 0;
                for (int i = 0; i < route.Count - 1; i++)
                {
                    totalDistance += problem.GetDistance(route[i], route[i + 1]);
                }
                totalDistance += problem.GetDistance(route.Last(), route.First());
                return totalDistance;
            }
        }
    }

}
