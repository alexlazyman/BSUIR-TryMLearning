using System.Linq;
using System.Collections.Generic;
using TryMLearning.Application.Interface.MachineLearning.Contexts;
using TryMLearning.Model;

namespace TryMLearning.Application.MachineLearning.Contexts
{
    public class ClassificationContext : IClassificationContext
    {
        public int GetNegativeCount(IEnumerable<ClassificationResult> classificationResults, int primaryClass)
        {
            return classificationResults.Count(r => r.ActualClass != primaryClass);
        }

        public int GetPositiveCount(IEnumerable<ClassificationResult> classificationResults, int primaryClass)
        {
            return classificationResults.Count(r => r.ActualClass == primaryClass);
        }

        public int GetFalseNegativeCount(IEnumerable<ClassificationResult> classificationResults, int primaryClass)
        {
            return classificationResults.Count(r => r.ExpectedClass == primaryClass && r.ActualClass != primaryClass);
        }

        public int GetFalsePositiveCount(IEnumerable<ClassificationResult> classificationResults, int primaryClass)
        {
            return classificationResults.Count(r => r.ExpectedClass != primaryClass && r.ActualClass == primaryClass);
        }

        public double GetFalsePositiveError(IEnumerable<ClassificationResult> classificationResults, int primaryClass)
        {
            double falsePositiveCount = GetFalsePositiveCount(classificationResults, primaryClass);
            double negativeCount = GetNegativeCount(classificationResults, primaryClass);

            return falsePositiveCount / negativeCount;
        }

        public double GetFalseNegativeError(IEnumerable<ClassificationResult> classificationResults, int primaryClass)
        {
            double falseNegativeCount = GetFalseNegativeCount(classificationResults, primaryClass);
            double positiveCount = GetPositiveCount(classificationResults, primaryClass);

            return falseNegativeCount / positiveCount;
        }
    }
}