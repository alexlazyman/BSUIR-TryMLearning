using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("ClassificationResult")]
    public class ClassificationResultDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => ClassificationResultId;
            set => ClassificationResultId = value;
        }

        [Key]
        public int ClassificationResultId { get; set; }

        public int AlgorithmEstimateId { get; set; }
        
        [ForeignKey(nameof(AlgorithmEstimateId))]
        public virtual AlgorithmEstimateDbEntity AlgorithmEstimate { get; set; }
        
        public int Index { get; set; }

        public int Count { get; set; }

        public ICollection<BoolTupleDbEntity> AnswerTuples { get; set; }
    }
}