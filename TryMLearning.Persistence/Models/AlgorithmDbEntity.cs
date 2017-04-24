using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
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

        int IDbEntity.Id
        {
            get => AlgorithmId;
            set => AlgorithmId = value;
        }

        [Key]
        public int AlgorithmId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [MaxLength(128)]
        [Index(IsUnique = true)]
        public string Alias { get; set; }

        public ICollection<AlgorithmParameterDbEntity> AlgorithmParameters { get; set; }
    }
}
