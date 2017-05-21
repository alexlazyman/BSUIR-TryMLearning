using System.Configuration;

namespace TryMLearning.Model.MachineLearning.Testers
{
    public class QFoldCrossValidationSection : ConfigurationSection
    {
        [ConfigurationProperty("q", DefaultValue = 10)]
        public int QFold => (int)this["q"];

        [ConfigurationProperty("primaryFeature", DefaultValue = 0)]
        public int PrimaryFeatureIndex => (int)this["primaryFeature"];
    }
}