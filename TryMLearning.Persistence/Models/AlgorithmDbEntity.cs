using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("Algorithm")]
    public class AlgorithmDbEntity : IDbEntity
    {
        public AlgorithmDbEntity()
        {
            AlgorithmParameters = new List<AlgorithmParameterDbEntity>();
        }

        int IDbEntity.Id { get => AlgorithmId; set => AlgorithmId = value; }

        [Key]
        public int AlgorithmId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<AlgorithmParameterDbEntity> AlgorithmParameters { get; set; }

        public virtual ICollection<AlgorithmSessionDbEntity> AlgorithmSessions { get; set; }
    }
}
