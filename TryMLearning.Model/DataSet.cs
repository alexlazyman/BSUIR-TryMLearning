using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TryMLearning.Model
{
    public class DataSet
    {
        public DataSet()
        {
        }

        public DataSet(int dataSetId)
        {
            DataSetId = dataSetId;
        }

        public int DataSetId { get; set; }

        public User Author { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DataSetType Type { get; set; }
    }
}