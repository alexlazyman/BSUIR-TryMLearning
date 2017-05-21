namespace TryMLearning.Model
{
    public class ClassificationResult
    {
        public int ClassificationResultId { get; set; }

        public int EstimationId { get; set; }

        public int Index { get; set; }

        public int ExpectedClass { get; set; }

        public int ActualClass { get; set; }
    }
}