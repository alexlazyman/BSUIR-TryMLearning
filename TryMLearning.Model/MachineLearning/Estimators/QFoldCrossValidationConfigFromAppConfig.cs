using System.Configuration;
using TryMLearning.Model.MachineLearning.Estimators.Interfaces;
using TryMLearning.Model.MachineLearning.Testers;

namespace TryMLearning.Model.MachineLearning.Estimators
{
    public class QFoldCrossValidationConfigFromAppConfig : IQFoldCrossValidationConfig
    {
        private readonly QFoldCrossValidationSection _config;

        public QFoldCrossValidationConfigFromAppConfig()
        {
            _config = (QFoldCrossValidationSection) ConfigurationManager.GetSection("qFoldCrossValidation");
        }

        public int QFold => _config.QFold;

        public int PrimaryFeatureIndex => _config.PrimaryFeatureIndex;
    }
}