using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmParameter")]
    public class AlgorithmParameterDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => AlgorithmParameterId;
            set => AlgorithmParameterId = value;
        }

        [Key]
        public int AlgorithmParameterId { get; set; }

        public int AlgorithmId { get; set; }

        [ForeignKey(nameof(AlgorithmId))]
        public virtual AlgorithmDbEntity Algorithm { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public short Order { get; set; }

        public AlgorithmParameterType ValueType { get; set; }
    }
}
