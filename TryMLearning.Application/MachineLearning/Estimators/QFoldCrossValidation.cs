using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Math;
using TryMLearning.Application.Interface.MachineLearning;
using TryMLearning.Application.Interface.MachineLearning.Classifiers;
using TryMLearning.Application.Interface.MachineLearning.EstimateResults;
using TryMLearning.Application.Interface.MachineLearning.Estimates;
using TryMLearning.Application.Interface.MachineLearning.Estimators;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Estimators.Configurations;
using TryMLearning.Model.MachineLearning.Reports;

namespace TryMLearning.Application.MachineLearning.Estimators
{
    public class QFoldCrossValidation : IClassifierEstimator
    {
        private readonly QFoldCrossValidationConfiguration _configuration;
        private readonly IEstimateFactory _estimateFactory;

        public QFoldCrossValidation(
            QFoldCrossValidationConfiguration configuration,
            IEstimateFactory estimateFactory)
        {
            _configuration = configuration;
            _estimateFactory = estimateFactory;
        }

        public ClassificationReport Estimate(IClassifier classifier, ClassificationSample[] samples, string[] estimateAliases)
        {
            var estimates = estimateAliases.Select(_estimateFactory.GetEstimate).ToArray();

            var classGroups = samples
                // Group by class
                .GroupBy(
                    s => s.ClassId,
                    (classId, sampleGroup) => sampleGroup.OrderBy(s => s.Features[_configuration.PrimaryFeature]).ToArray())
                // Divede group on folds
                .Select(
                    g => g.Split((int)Math.Ceiling((double)g.Length / _configuration.QFold)))
                .ToArray();

            for (int q = 0; q < _configuration.QFold; q++)
            {
                var trainSamples = new List<ClassificationSample>();
                var controlSamples = new List<ClassificationSample>();

                for (int i = 0; i < _configuration.QFold; i++)
                {
                    var targetSamples = i == q ? controlSamples : trainSamples;

                    for (int g = 0; g < classGroups.Length; g++)
                    {
                        targetSamples.AddRange(classGroups[g][i]);
                    }
                }

                classifier.Train(trainSamples);

                var results = classifier.Check(controlSamples).ToArray();

                for (int i = 0; i < estimates.Length; i++)
                {
                    estimates[i].Estimate(results, true);
                }
            }

            var classificationReport = new ClassificationReport();

            for (int i = 0; i < estimates.Length; i++)
            {
                var estimateResult = estimates[i].Average;

                estimateResult.Render(classificationReport);
            }

            return classificationReport;
        }
    }
}