using System.Collections.Generic;
using TryMLearning.Model;
using TryMLearning.Model.Constants;

namespace TryMLearning.Data
{
    // TODO: Move data to files.
    public static class DefaultData
    {
        public static IEnumerable<Algorithm> GetAlgorithms()
        {
            yield return new Algorithm
            {
                AlgorithmId = 1,
                Name = "Naive Bayes",
                Description = "There is no description",
                Alias = AlgorithmAliases.NaiveBayes,
                Parameters = new List<AlgorithmParameter>
                {
                }
            };
        }

        public static IEnumerable<DataSet> GetDataSets()
        {
            yield return new DataSet
            {
                DataSetId = 1,
                Name = "Iris",
                Description = "There is no description",
                Type = DataSetType.Classification
            };
        }

        public static IEnumerable<AlgorithmEstimator> GetAlgorithmEstimators()
        {
            yield return new AlgorithmEstimator
            {
                AlgorithmEstimatorId = 1,
                Alias = ClassifierEstimatorAliases.QFoldCrossValidation,
                Name = "Q-fold cross validation",
                Description = "There is no description",
            };
        }

        public static IEnumerable<ClassificationSample> GetClassificationDataSetSamples()
        {
            #region Iris

            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.1, 3.5, 1.4, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.9, 3.0, 1.4, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.7, 3.2, 1.3, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.6, 3.1, 1.5, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 3.6, 1.4, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.4, 3.9, 1.7, 0.4 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.6, 3.4, 1.4, 0.3 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 3.4, 1.5, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.4, 2.9, 1.4, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.9, 3.1, 1.5, 0.1 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.4, 3.7, 1.5, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.8, 3.4, 1.6, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.8, 3.0, 1.4, 0.1 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.3, 3.0, 1.1, 0.1 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.8, 4.0, 1.2, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.7, 4.4, 1.5, 0.4 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.4, 3.9, 1.3, 0.4 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.1, 3.5, 1.4, 0.3 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.7, 3.8, 1.7, 0.3 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.1, 3.8, 1.5, 0.3 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.4, 3.4, 1.7, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.1, 3.7, 1.5, 0.4 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.6, 3.6, 1.0, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.1, 3.3, 1.7, 0.5 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.8, 3.4, 1.9, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 3.0, 1.6, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 3.4, 1.6, 0.4 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.2, 3.5, 1.5, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.2, 3.4, 1.4, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.7, 3.2, 1.6, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.8, 3.1, 1.6, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.4, 3.4, 1.5, 0.4 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.2, 4.1, 1.5, 0.1 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.5, 4.2, 1.4, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.9, 3.1, 1.5, 0.1 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 3.2, 1.2, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.5, 3.5, 1.3, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.9, 3.1, 1.5, 0.1 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.4, 3.0, 1.3, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.1, 3.4, 1.5, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 3.5, 1.3, 0.3 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.5, 2.3, 1.3, 0.3 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.4, 3.2, 1.3, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 3.5, 1.6, 0.6 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.1, 3.8, 1.9, 0.4 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.8, 3.0, 1.4, 0.3 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.1, 3.8, 1.6, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.6, 3.2, 1.4, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.3, 3.7, 1.5, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 3.3, 1.4, 0.2 }, ClassId = 0 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.0, 3.2, 4.7, 1.4 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.4, 3.2, 4.5, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.9, 3.1, 4.9, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.5, 2.3, 4.0, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.5, 2.8, 4.6, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.7, 2.8, 4.5, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.3, 3.3, 4.7, 1.6 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.9, 2.4, 3.3, 1.0 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.6, 2.9, 4.6, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.2, 2.7, 3.9, 1.4 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 2.0, 3.5, 1.0 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.9, 3.0, 4.2, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.0, 2.2, 4.0, 1.0 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.1, 2.9, 4.7, 1.4 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.6, 2.9, 3.6, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.7, 3.1, 4.4, 1.4 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.6, 3.0, 4.5, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.8, 2.7, 4.1, 1.0 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.2, 2.2, 4.5, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.6, 2.5, 3.9, 1.1 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.9, 3.2, 4.8, 1.8 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.1, 2.8, 4.0, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.3, 2.5, 4.9, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.1, 2.8, 4.7, 1.2 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.4, 2.9, 4.3, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.6, 3.0, 4.4, 1.4 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.8, 2.8, 4.8, 1.4 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.7, 3.0, 5.0, 1.7 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.0, 2.9, 4.5, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.7, 2.6, 3.5, 1.0 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.5, 2.4, 3.8, 1.1 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.5, 2.4, 3.7, 1.0 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.8, 2.7, 3.9, 1.2 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.0, 2.7, 5.1, 1.6 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.4, 3.0, 4.5, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.0, 3.4, 4.5, 1.6 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.7, 3.1, 4.7, 1.5 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.3, 2.3, 4.4, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.6, 3.0, 4.1, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.5, 2.5, 4.0, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.5, 2.6, 4.4, 1.2 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.1, 3.0, 4.6, 1.4 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.8, 2.6, 4.0, 1.2 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.0, 2.3, 3.3, 1.0 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.6, 2.7, 4.2, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.7, 3.0, 4.2, 1.2 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.7, 2.9, 4.2, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.2, 2.9, 4.3, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.1, 2.5, 3.0, 1.1 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.7, 2.8, 4.1, 1.3 }, ClassId = 1 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.3, 3.3, 6.0, 2.5 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.8, 2.7, 5.1, 1.9 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.1, 3.0, 5.9, 2.1 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.3, 2.9, 5.6, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.5, 3.0, 5.8, 2.2 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.6, 3.0, 6.6, 2.1 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 4.9, 2.5, 4.5, 1.7 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.3, 2.9, 6.3, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.7, 2.5, 5.8, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.2, 3.6, 6.1, 2.5 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.5, 3.2, 5.1, 2.0 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.4, 2.7, 5.3, 1.9 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.8, 3.0, 5.5, 2.1 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.7, 2.5, 5.0, 2.0 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.8, 2.8, 5.1, 2.4 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.4, 3.2, 5.3, 2.3 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.5, 3.0, 5.5, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.7, 3.8, 6.7, 2.2 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.7, 2.6, 6.9, 2.3 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.0, 2.2, 5.0, 1.5 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.9, 3.2, 5.7, 2.3 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.6, 2.8, 4.9, 2.0 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.7, 2.8, 6.7, 2.0 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.3, 2.7, 4.9, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.7, 3.3, 5.7, 2.1 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.2, 3.2, 6.0, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.2, 2.8, 4.8, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.1, 3.0, 4.9, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.4, 2.8, 5.6, 2.1 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.2, 3.0, 5.8, 1.6 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.4, 2.8, 6.1, 1.9 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.9, 3.8, 6.4, 2.0 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.4, 2.8, 5.6, 2.2 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.3, 2.8, 5.1, 1.5 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.1, 2.6, 5.6, 1.4 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 7.7, 3.0, 6.1, 2.3 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.3, 3.4, 5.6, 2.4 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.4, 3.1, 5.5, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.0, 3.0, 4.8, 1.8 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.9, 3.1, 5.4, 2.1 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.7, 3.1, 5.6, 2.4 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.9, 3.1, 5.1, 2.3 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.8, 2.7, 5.1, 1.9 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.8, 3.2, 5.9, 2.3 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.7, 3.3, 5.7, 2.5 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.7, 3.0, 5.2, 2.3 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.3, 2.5, 5.0, 1.9 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.5, 3.0, 5.2, 2.0 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 6.2, 3.4, 5.4, 2.3 }, ClassId = 2 };
            yield return new ClassificationSample { DataSetId = 1, Features = new[] { 5.9, 3.0, 5.1, 1.8 }, ClassId = 2 };

            #endregion
        }
    }
}