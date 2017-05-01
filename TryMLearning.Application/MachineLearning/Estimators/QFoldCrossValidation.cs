using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class QFoldCrossValidation : IClassifierService
    {
        private readonly QFoldCrossValidationConfiguration _configuration;

        public QFoldCrossValidation(QFoldCrossValidationConfiguration configuration)
        {
            _configuration = configuration ?? new QFoldCrossValidationConfiguration();
        }

        public IEnumerable<ClassificationResult> Classify(IEnumerable<ClassificationSample> samples, IClassifier classifier)
        {
            var classGroups = samples
                // Group by class
                .GroupBy(
                    s => s.ClassId,
                    (classId, sampleGroup) => sampleGroup.OrderBy(s => s.Features[_configuration.PrimaryFeatureIndex]).ToArray())
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

                var answers = classifier.Check(controlSamples).ToArray();

                yield return new ClassificationResult
                {
                    Index = q,
                    Answers = answers
                };
            }
        }
    }
}