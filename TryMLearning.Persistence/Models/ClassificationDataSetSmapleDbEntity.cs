using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;
using TryMLearning.Persistence.Models.Map;

namespace TryMLearning.Persistence.Models
{
    [Table("ClassificationDataSetSmaple")]
    public class ClassificationDataSetSmapleDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => ClassificationDataSetSmapleId;
            set => ClassificationDataSetSmapleId = value;
        }

        [Key]
        public int ClassificationDataSetSmapleId { get; set; }

        public int DataSetId { get; set; }
        
        [ForeignKey(nameof(DataSetId))]
        public virtual DataSetDbEntity DataSet { get; set; }

        [MaxLength(256)]
        public string ClassName { get; set; }

        public int Count { get; set; }

        public ICollection<ClassificationDataSetSmapleDoubleTupleMap> DoubleTupleMaps { get; set; }
    }
}