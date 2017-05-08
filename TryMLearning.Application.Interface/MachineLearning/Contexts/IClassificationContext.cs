using System;
using System.Collections.Generic;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning.Contexts
{
    public interface IClassificationContext
    {
        int GetNegativeCount(List<ClassificationResult> classificationResults, int primaryClass);

        int GetPositiveCount(List<ClassificationResult> classificationResults, int primaryClass);

        int GetFalseNegativeCount(List<ClassificationResult> classificationResults, int primaryClass);

        int GetFalsePositiveCount(List<ClassificationResult> classificationResults, int primaryClass);
        
        double GetFalsePositiveError(List<ClassificationResult> classificationResults, int primaryClass);

        double GetFalseNegativeError(List<ClassificationResult> classificationResults, int primaryClass);
    }
}