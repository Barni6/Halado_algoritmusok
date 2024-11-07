using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_halal.ImageSegmentationProblem
{
    internal class KMeans
    {
        private int k; 

        public KMeans(int k)
        {
            this.k = k;
        }

        public Bitmap Apply(Bitmap inputImage)
        {
            Color[] pixels = GetPixels(inputImage);

            Random rand = new Random();
            Color[] centroids = new Color[k];
            for (int i = 0; i < k; i++)
            {
                centroids[i] = pixels[rand.Next(pixels.Length)];
            }

            for (int iter = 0; iter < 100; iter++) 
            {
                int[] clusterAssignments = AssignClusters(pixels, centroids);

                centroids = UpdateCentroids(pixels, clusterAssignments, centroids);
            }

            Bitmap segmented = CreateSegmentedImage(inputImage, pixels, centroids);

            return segmented;
        }

        private Color[] GetPixels(Bitmap image)
        {
            List<Color> pixels = new List<Color>();

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    pixels.Add(image.GetPixel(x, y));
                }
            }

            return pixels.ToArray();
        }

        private int[] AssignClusters(Color[] pixels, Color[] centroids)
        {
            int[] clusterAssignments = new int[pixels.Length];
            for (int i = 0; i < pixels.Length; i++)
            {
                Color pixel = pixels[i];
                int closestCentroidIndex = 0;
                double closestDistance = Distance(pixel, centroids[0]);
                for (int j = 1; j < centroids.Length; j++)
                {
                    double distance = Distance(pixel, centroids[j]);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestCentroidIndex = j;
                    }
                }
                clusterAssignments[i] = closestCentroidIndex;
            }
            return clusterAssignments;
        }

        private Color[] UpdateCentroids(Color[] pixels, int[] clusterAssignments, Color[] centroids)
        {
            int[] clusterSizes = new int[k];
            int[] rSums = new int[k];
            int[] gSums = new int[k];
            int[] bSums = new int[k];

            for (int i = 0; i < pixels.Length; i++)
            {
                Color pixel = pixels[i];
                int clusterIndex = clusterAssignments[i];
                clusterSizes[clusterIndex]++;
                rSums[clusterIndex] += pixel.R;
                gSums[clusterIndex] += pixel.G;
                bSums[clusterIndex] += pixel.B;
            }

            for (int i = 0; i < k; i++)
            {
                int clusterSize = clusterSizes[i];
                centroids[i] = Color.FromArgb(rSums[i] / clusterSize, gSums[i] / clusterSize, bSums[i] / clusterSize);
            }

            return centroids;
        }

        private double Distance(Color a, Color b)
        {
            double dr = a.R - b.R;
            double dg = a.G - b.G;
            double db = a.B - b.B;
            return Math.Sqrt(dr * dr + dg * dg + db * db);
        }

        private Bitmap CreateSegmentedImage(Bitmap inputImage, Color[] pixels, Color[] centroids)
        {
            Bitmap segmented = new Bitmap(inputImage.Width, inputImage.Height);

            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    int index = y * inputImage.Width + x;
                    int clusterIndex = AssignCluster(pixels[index], centroids);
                    segmented.SetPixel(x, y, centroids[clusterIndex]);
                }
            }

            return segmented;
        }

        private int AssignCluster(Color pixel, Color[] centroids)
        {
            int closestCentroidIndex = 0;
            double closestDistance = Distance(pixel, centroids[0]);
            for (int j = 1; j < centroids.Length; j++)
            {
                double distance = Distance(pixel, centroids[j]);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCentroidIndex = j;
                }
            }
            return closestCentroidIndex;
        }
    }
}
