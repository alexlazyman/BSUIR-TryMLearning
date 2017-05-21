using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("ClassAlias")]
    public class ClassAliasDbEntity
    {
        [Key]
        [Column(Order = 0)]
        [Index("DataSetAndClass", 0, IsUnique = true)]
        public int DataSetId { get; set; }

        [ForeignKey(nameof(DataSetId))]
        public DataSetDbEntity DataSet { get; set; }

        [Key]
        [Column(Order = 1)]
        [Index("DataSetAndClass", 1)]
        public int ClassId { get; set; }

        [MaxLength(256)]
        public string Alias { get; set; }
    }
}
