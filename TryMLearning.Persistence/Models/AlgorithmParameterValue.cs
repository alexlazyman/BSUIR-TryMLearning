using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmParameterValue")]
    public class AlgorithmParameterValueDbEntity
    {
        [Key]
        public int AlgorithmParameterValueId { get; set; }

        public int AlgorithmParameterId { get; set; }

        public int AlgorithmSessionId { get; set; }

        public string Value { get; set; }
    }
}