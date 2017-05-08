using System.Configuration;
using TryMLearning.Model.MachineLearning.Estimators.Interfaces;

namespace TryMLearning.Model.MachineLearning.Estimators
{
    public class DefaultQFoldCrossValidationConfig : IQFoldCrossValidationConfig
    {
        private readonly QFoldCrossValidationSection _config;

        public DefaultQFoldCrossValidationConfig()
        {
            _config = (QFoldCrossValidationSection) ConfigurationManager.GetSection("qFoldCrossValidation");
        }

        public int QFold => _config.QFold;

        public int PrimaryFeatureIndex => _config.PrimaryFeatureIndex;
    }

    public class QFoldCrossValidationSection : ConfigurationSection
    {
        [ConfigurationProperty("q", DefaultValue = 10)]
        public int QFold => (int)this["q"];

        [ConfigurationProperty("primaryFeature", DefaultValue = 0)]
        public int PrimaryFeatureIndex => (int)this["primaryFeature"];
    }
}