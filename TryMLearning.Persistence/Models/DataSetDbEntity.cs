using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("DataSet")]
    public class DataSetDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => DataSetId;
            set => DataSetId = value;
        }

        [Key]
        public int DataSetId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }
    }
}