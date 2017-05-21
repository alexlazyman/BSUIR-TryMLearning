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

        public int EstimationId { get; set; }
        
        [ForeignKey(nameof(EstimationId))]
        public virtual EstimationDbEntity Estimation { get; set; }

        public int Index { get; set; }

        public int ExpectedClass { get; set; }

        public int ActualClass { get; set; }
    }
}