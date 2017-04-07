using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryMLearning.Persistence.Models
{
    [Table("Algorithm")]
    public class AlgorithmDbEntity
    {
        public AlgorithmDbEntity()
        {
            Parameters = new List<AlgorithmParameterDbEntity>();
        }

        [Key]
        public int AlgorithmId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<AlgorithmParameterDbEntity> Parameters { get; set; }
    }
}
