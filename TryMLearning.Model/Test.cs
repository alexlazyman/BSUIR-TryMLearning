using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Test
    {
        public Test()
        {
        }

        public Test(int testId)
        {
            TestId = testId;
        }

        public int TestId { get; set; }

        public string Alias { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}