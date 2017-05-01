namespace TryMLearning.Model
{
    public class ClassificationResult
    {
        public int ClassificationResultId { get; set; }

        public int AlgorithmEstimateId { get; set; }

        public int Index { get; set; }

        public bool[] Answers { get; set; }
    }
}