using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmParameterValue")]
    public class AlgorithmParameterValueDbEntity : IDbEntity
    {
        int IDbEntity.Id { get => AlgorithmParameterValueId; set => AlgorithmParameterValueId = value; }

        [Key]
        public int AlgorithmParameterValueId { get; set; }

        public int AlgorithmParameterId { get; set; }

        public virtual AlgorithmParameterDbEntity AlgorithmParameter { get; set; }

        public int AlgorithmSessionId { get; set; }

        public virtual AlgorithmSessionDbEntity AlgorithmSession { get; set; }

        public string Value { get; set; }
    }
}