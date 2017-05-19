using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.Statistics.Distributions;
using Accord.Statistics.Distributions.Multivariate;
using Accord.Statistics.Distributions.Univariate;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Classifiers
{
    public class NaiveBayesClassifier : IClassifier
    {
        private const string DistributionAlias = "Distribution";

        private DistributionType _distributionType;

        private NaiveBayesLearning<NormalDistribution> _gaussianBayesTeacher = null;
        private NaiveBayes<NormalDistribution> _gaussianBayes = null;

        private NaiveBayesLearning<PoissonDistribution> _poissonBayesTeacher = null;
        private NaiveBayes<PoissonDistribution> _poissonBayes = null;

        public NaiveBayesClassifier()
        {
        }

        public void Init(List<AlgorithmParameterValuePair> config)
        {
            _distributionType = (DistributionType) config.Single(p => p.Parameter.Name == DistributionAlias).Value.IntValue.Value;

            Init();
        }

        public void Train(IEnumerable<ClassificationSample> samples)
        {
            double[][] inputs = samples.Select(s => s.Features).ToArray();
            int[] outputs = samples.Select(s => s.ClassId).ToArray();

            Train(inputs, outputs);
        }

        public int Decide(ClassificationSample sample)
        {
            return Decide(sample.Features);
        }

        private void Init()
        {

            switch (_distributionType)
            {
                case DistributionType.Gaussian:
                    _gaussianBayesTeacher = new NaiveBayesLearning<NormalDistribution>();
                    return;
                case DistributionType.Poisson:
                    _poissonBayesTeacher = new NaiveBayesLearning<PoissonDistribution>();
                    return;
                default:
                    throw new NotImplementedException();
            }
        }

        private void Train(double[][] inputs, int[] outputs)
        {
            switch (_distributionType)
            {
                case DistributionType.Gaussian:
                    _gaussianBayes = _gaussianBayesTeacher.Learn(inputs, outputs);
                    return;
                case DistributionType.Poisson:
                    _poissonBayes = _poissonBayesTeacher.Learn(inputs, outputs);
                    return;
                default:
                    throw new NotImplementedException();
            }
        }

        private int Decide(double[] input)
        {
            switch (_distributionType)
            {
                case DistributionType.Gaussian:
                    return _gaussianBayes.Decide(input);
                case DistributionType.Poisson:
                    return _poissonBayes.Decide(input);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}