using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.Statistics.Distributions.Univariate;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Classifiers
{
    public class NaiveBayesClassifier : IClassifier
    {
        private NaiveBayes<NormalDistribution> _bayes = null;

        public void Train(IEnumerable<ClassificationSample> samples)
        {
            double[][] inputs = samples.Select(s => s.Features).ToArray();
            int[] outputs = samples.Select(s => s.ClassId).ToArray();

            var teacher = new NaiveBayesLearning<NormalDistribution>();

            _bayes = teacher.Learn(inputs, outputs);
        }

        public IEnumerable<bool> Check(IEnumerable<ClassificationSample> samples)
        {
            foreach (var sample in samples)
            {
                yield return _bayes.Decide(sample.Features) == sample.ClassId;
            }
        }
    }
}