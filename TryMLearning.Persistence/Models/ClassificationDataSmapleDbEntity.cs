using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("ClassificationDataSmaple")]
    public class ClassificationDataSmapleDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => ClassificationDataSmapleId;
            set => ClassificationDataSmapleId = value;
        }

        [Key]
        public int ClassificationDataSmapleId { get; set; }

        public int DataSetId { get; set; }
        
        [ForeignKey(nameof(DataSetId))]
        public virtual DataSetDbEntity DataSet { get; set; }

        [MaxLength(256)]
        public string ClassName { get; set; }

        public int DoubleTupleId { get; set; }

        [ForeignKey(nameof(DoubleTupleId))]
        public virtual DoubleTupleDbEntity DoubleTuple { get; set; }
    }
}