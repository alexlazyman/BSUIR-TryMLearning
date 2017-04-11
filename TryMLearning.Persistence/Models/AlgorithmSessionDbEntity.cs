using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmSession")]
    public class AlgorithmSessionDbEntity : IDbEntity
    {
        int IDbEntity.Id { get => AlgorithmSessionId; set => AlgorithmSessionId = value; }

        [Key]
        public int AlgorithmSessionId { get; set; }

        public int AlgorithmId { get; set; }

        public virtual AlgorithmDbEntity Algorithm { get; set; }

        public AlgorithmSessionStatus Status { get; set; }

        public ICollection<AlgorithmParameterValueDbEntity> AlgorithmParameterValues { get; set; }
    }
}
