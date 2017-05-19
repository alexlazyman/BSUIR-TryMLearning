using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmEstimation")]
    public class AlgorithmEstimationDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => AlgorithmEstimationId;
            set => AlgorithmEstimationId = value;
        }

        [Key]
        public int AlgorithmEstimationId { get; set; }

        public AlgorithmEstimationStatus Status { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserDbEntity User { get; set; }

        public int AlgorithmId { get; set; }

        [ForeignKey(nameof(AlgorithmId))]
        public virtual AlgorithmDbEntity Algorithm { get; set; }

        public int DataSetId { get; set; }

        [ForeignKey(nameof(DataSetId))]
        public virtual DataSetDbEntity DataSet { get; set; }

        public ICollection<AlgorithmParameterValueDbEntity> AlgorithmParameterValues { get; set; }
    }
}
