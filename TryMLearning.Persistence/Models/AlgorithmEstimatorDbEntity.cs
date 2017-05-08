using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmEstimator")]
    public class AlgorithmEstimatorDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => AlgorithmEstimatorId;
            set => AlgorithmEstimatorId = value;
        }

        [Key]
        public int AlgorithmEstimatorId { get; set; }

        [MaxLength(128)]
        [Index(IsUnique = true)]
        public string Alias { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }
    }
}
