using System.Linq;
using System.Threading.Tasks;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.Statistics.Distributions.Univariate;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.DataSetSampleStreams;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Classifiers
{
    public class NaiveBayesClassifier : IClassifier
    {
        public async Task ComputeAsync(IDataSetSampleStream<ClassificationDataSetSmaple> stream)
        {
            var samples = await stream.ReadAllAsync();

            double[][] inputs = samples.Select(s => s.Values).ToArray();
            int[] outputs = samples.Select(s => s.ClassId).ToArray();

            var teacher = new NaiveBayesLearning<NormalDistribution>();

            // Estimate the model using the data
            NaiveBayes<NormalDistribution> bayes = teacher.Learn(inputs, outputs);

            var testResult = bayes.Decide(inputs);
        }
    }
}