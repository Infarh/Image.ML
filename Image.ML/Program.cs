using System;
using System.IO;
using Image.ML.Model;

namespace Image.ML
{
    // https://code-ai.mk/how-to-use-ml-net-model-builder-for-image-classification/
    class Program
    {
        static void Main(string[] args)
        {
            var sample_data = new ModelInput { ImageSource = @"img\cat1.jpg" };
            var result = ConsumeModel.Predict(sample_data);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Label with predicted Label from sample data...\n\n");
            Console.WriteLine($"ImageSource: {sample_data.ImageSource}");
            Console.WriteLine($"\n\nPredicted Label value {result.Prediction} \nPredicted Label scores: [{string.Join(",", result.Score)}]\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
