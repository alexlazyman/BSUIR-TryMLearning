using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accord.Math;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.Estimates.Classifier;
using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Estimators;
using TryMLearning.Model.MachineLearning.Estimators.Interfaces;

namespace TryMLearning.Application.MachineLearning.Estimators
{
    public class QFoldCrossValidation : IClassifierEstimator
    {
        private readonly IQFoldCrossValidationConfig _config;

        public QFoldCrossValidation(IQFoldCrossValidationConfig config)
        {
            _config = config;
        }

        public List<ClassificationResult> Classify(IEnumerable<ClassificationSample> samples, IClassifier classifier)
        {
            var classGroups = samples
                // Group by class
                .GroupBy(
                    s => s.ClassId,
                    (classId, sampleGroup) => sampleGroup.OrderBy(s => s.Features[_config.PrimaryFeatureIndex]).ToArray())
                // Divede group on folds
                .Select(
                    g => g.Split((int)Math.Ceiling((double)g.Length / _config.QFold)))
                .ToArray();

            var classificationResults = new List<ClassificationResult>();

            for (int q = 0; q < _config.QFold; q++)
            {
                var trainSamples = new List<ClassificationSample>();
                var controlSamples = new List<ClassificationSample>();

                for (int i = 0; i < _config.QFold; i++)
                {
                    var targetSamples = i == q ? controlSamples : trainSamples;

                    for (int g = 0; g < classGroups.Length; g++)
                    {
                        targetSamples.AddRange(classGroups[g][i]);
                    }
                }

                classifier.Train(trainSamples);

                classificationResults.AddRange(controlSamples.Select(sample => new ClassificationResult
                {
                    Index = q,
                    ExpectedClass = sample.ClassId,
                    ActualClass = classifier.Decide(sample)
                }));
            }

            return classificationResults;
        }

        public List<EstimateResponse> Estimate(List<ClassificationResult> classificationResults, List<IClassifierEstimate> estimates)
        {
            var resultGroups = classificationResults.GroupBy(s => s.Index);

            foreach (var resultGroup in resultGroups)
            {
                foreach (var estimate in estimates)
                {
                    estimate.Estimate(resultGroup.ToList());
                }
            }

            var estimateResults = estimates.Select(e => e.Average).ToList();

            return estimateResults;
        }
    }
}