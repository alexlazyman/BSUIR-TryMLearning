using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Models
{
    [Table("AlgorithmSession")]
    public class AlgorithmSessionDbEntity
    {
        [Key]
        public int AlgorithmSessionId { get; set; }

        public int AlgorithmId { get; set; }

        protected virtual AlgorithmDbEntity Algorithm { get; set; }

        public AlgorithmSessionStatus Status { get; set; }

        public IList<AlgorithmParameterValueDbEntity> Parameters { get; set; }
    }
}
