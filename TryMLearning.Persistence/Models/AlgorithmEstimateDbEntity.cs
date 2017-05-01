using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmEstimate")]
    public class AlgorithmEstimateDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => AlgorithmEstimateId;
            set => AlgorithmEstimateId = value;
        }

        [Key]
        public int AlgorithmEstimateId { get; set; }

        public AlgorithmEstimateStatus Status { get; set; }

        public int AlgorithmId { get; set; }

        [ForeignKey(nameof(AlgorithmId))]
        public virtual AlgorithmDbEntity Algorithm { get; set; }

        public int DataSetId { get; set; }

        [ForeignKey(nameof(DataSetId))]
        public virtual DataSetDbEntity DataSet { get; set; }

        public int TestId { get; set; }

        [ForeignKey(nameof(TestId))]
        public virtual TestDbEntity Test { get; set; }

        public ICollection<AlgorithmParameterValueDbEntity> AlgorithmParameterValues { get; set; }
    }
}
