﻿using System.Collections.Generic;
using System.Linq;
using TryMLearning.Application.Interface.MachineLearning.Contexts;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.Estimates.Classifier;

namespace TryMLearning.Application.MachineLearning.Estimates.Classifier.FalsePositiveError
{
    public class FalsePositiveError : BaseClassifierEstimate<FalsePositiveErrorResult>
    {
        private readonly FPErrorEstimateConfig _config;

        private readonly IClassificationContext _classificationContext;

        public FalsePositiveError(
            FPErrorEstimateConfig config,
            IClassificationContext classificationContext)
        {
            _config = config;
            _classificationContext = classificationContext;
        }

        protected override FalsePositiveErrorResult GetEstimateResult(List<ClassificationResult> classificationResults)
        {
            var falsePositiveError = _classificationContext.GetFalsePositiveError(classificationResults, _config.PrimaryClass);

            return new FalsePositiveErrorResult(falsePositiveError);
        }

        protected override FalsePositiveErrorResult GetAverageResult(List<FalsePositiveErrorResult> estimateResults)
        {
            var falsePositiveError = estimateResults.Sum(r => r.FalsePositiveError) / estimateResults.Count;

            return new FalsePositiveErrorResult(falsePositiveError);
        }
    }
}