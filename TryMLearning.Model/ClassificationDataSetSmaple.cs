namespace TryMLearning.Model
{
    public class ClassificationDataSetSmaple
    {
        public int ClassificationDataSetSmapleId { get; set; }

        public int DataSetId { get; set; }

        public string ClassName { get; set; }

        public double[] Values { get; set; }
    }
}