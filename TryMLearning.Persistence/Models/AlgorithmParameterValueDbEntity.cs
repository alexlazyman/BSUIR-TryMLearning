using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmParameterValue")]
    public class AlgorithmParameterValueDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => AlgorithmParameterValueId;
            set => AlgorithmParameterValueId = value;
        }

        [Key]
        public int AlgorithmParameterValueId { get; set; }

        public int AlgorithmParameterId { get; set; }

        [ForeignKey(nameof(AlgorithmParameterId))]
        public virtual AlgorithmParameterDbEntity AlgorithmParameter { get; set; }

        public int AlgorithmSessionId { get; set; }

        [ForeignKey(nameof(AlgorithmSessionId))]
        public virtual AlgorithmSessionDbEntity AlgorithmSession { get; set; }

        [Column("IntVal")]
        public int? IntValue { get; set; }

        [Column("DoubleVal")]
        public double? DoubleValue { get; set; }

        [MaxLength(1024)]
        [Column("StringVal")]
        public string StringValue { get; set; }
    }
}