using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_halal.ImageSegmentationProblem
{
    internal class ImageSegmentation
    {
        private int k; 

        public ImageSegmentation(int k)
        {
            this.k = k;
        }

        public void Segment(string inputImagePath, string outputImagePath)
        {
            Bitmap inputImage = new Bitmap(inputImagePath);

            KMeans kMeans = new KMeans(k);
            Bitmap segmented = kMeans.Apply(inputImage);

            segmented.Save(outputImagePath);
        }
    }
}
