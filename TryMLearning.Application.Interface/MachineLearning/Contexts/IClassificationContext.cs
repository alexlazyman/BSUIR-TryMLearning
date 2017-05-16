using System.Collections.Generic;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning.Contexts
{
    public interface IClassificationContext
    {
        int GetNegativeCount(IEnumerable<ClassificationResult> classificationResults, int primaryClass);

        int GetPositiveCount(IEnumerable<ClassificationResult> classificationResults, int primaryClass);

        int GetFalseNegativeCount(IEnumerable<ClassificationResult> classificationResults, int primaryClass);

        int GetFalsePositiveCount(IEnumerable<ClassificationResult> classificationResults, int primaryClass);
        
        double GetFalsePositiveError(IEnumerable<ClassificationResult> classificationResults, int primaryClass);

        double GetFalseNegativeError(IEnumerable<ClassificationResult> classificationResults, int primaryClass);
    }
}