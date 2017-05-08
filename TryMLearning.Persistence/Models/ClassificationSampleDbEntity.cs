using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("ClassificationSample")]
    public class ClassificationSampleDbEntity : IDbEntity
    {
        int IDbEntity.Id
        {
            get => ClassificationSampleId;
            set => ClassificationSampleId = value;
        }

        [Key]
        public int ClassificationSampleId { get; set; }

        public int DataSetId { get; set; }
        
        [ForeignKey(nameof(DataSetId))]
        public virtual DataSetDbEntity DataSet { get; set; }
        
        public int ClassId { get; set; }

        public int Count { get; set; }

        public ICollection<DoubleTupleDbEntity> FeatureTuples { get; set; }
    }
}