using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmParameter")]
    public class AlgorithmParameterDbEntity
    {
        [Key]
        public int AlgorithmParameterId { get; set; }

        public int AlgorithmId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        public short SequentialNumber { get; set; }

        public AlgorithmParameterType ValueType { get; set; }

        public string DefaultValue { get; set; }

        public bool Editable { get; set; }
    }
}
