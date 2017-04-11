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
        int IDbEntity.Id { get => AlgorithmParameterId; set => AlgorithmParameterId = value; }

        [Key]
        public int AlgorithmParameterId { get; set; }

        public int AlgorithmId { get; set; }

        public virtual AlgorithmDbEntity Algorithm { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        public short SequentialNumber { get; set; }

        public AlgorithmParameterType ValueType { get; set; }

        public string DefaultValue { get; set; }

        public bool Editable { get; set; }

        public virtual ICollection<AlgorithmParameterValueDbEntity> AlgorithmParameterValues { get; set; }
    }
}
